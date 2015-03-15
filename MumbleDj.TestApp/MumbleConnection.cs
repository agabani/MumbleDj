using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using MumbleDj.Packets;
using ProtoBuf;
using Version = MumbleDj.Packets.Version;

namespace MumbleDj.TestApp
{
    public class MumbleConnection : IDisposable
    {
        private readonly MumbleAddress _mumbleAddress;
        private readonly MumbleCallback _mumbleCallback;
        private DateTime _lastSentPing = DateTime.MinValue;
        private TcpClient _tcpClient;
        private NetworkStream _tcpNetworkStream;
        private BinaryReader _tcpReader;
        private SslStream _tcpSslStream;
        private BinaryWriter _tcpWriter;

        public MumbleConnection(MumbleAddress mumbleAddress, MumbleCallback mumbleCallback)
        {
            ConnectionState = ConnectionStates.Disconnected;
            _mumbleAddress = mumbleAddress;
            _mumbleCallback = mumbleCallback;
        }

        public ConnectionStates ConnectionState { get; private set; }

        public void Dispose()
        {
            ConnectionState = ConnectionStates.Disconnecting;

            if (_tcpReader != null)
            {
                _tcpReader.Dispose();
            }

            if (_tcpWriter != null)
            {
                _tcpWriter.Dispose();
            }

            if (_tcpSslStream != null)
            {
                _tcpSslStream.Dispose();
            }

            if (_tcpNetworkStream != null)
            {
                _tcpNetworkStream.Dispose();
            }

            if (_tcpClient.Connected)
            {
                _tcpClient.Close();
            }

            ConnectionState = ConnectionStates.Disconnected;
        }

        public void Connect(MumbleCredentials mumbleCredentials)
        {
            ConnectionState = ConnectionStates.Connecting;

            _tcpClient = new TcpClient(_mumbleAddress.Address, _mumbleAddress.Port);
            _tcpNetworkStream = _tcpClient.GetStream();
            _tcpSslStream = new SslStream(_tcpNetworkStream, false, ValidateServerCertificate, null);

            _tcpSslStream.AuthenticateAsClient(_mumbleAddress.Address);

            _tcpReader = new BinaryReader(_tcpSslStream);
            _tcpWriter = new BinaryWriter(_tcpSslStream);

            Handshake(mumbleCredentials);

            ConnectionState = ConnectionStates.Connected;
        }

        public void Disconnect()
        {
            Dispose();
        }

        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private void Handshake(MumbleCredentials mumbleCredentials)
        {
            var version = new Version
            {
                ReleaseVersion = (1 << 16) | (2 << 8) | (8 & 0xFF),
                Release = "Mumble Dj",
                Os = Environment.OSVersion.ToString(),
                OsVersion = Environment.OSVersion.VersionString
            };

            Send(PacketType.Version, version);

            var authenticate = new Authenticate
            {
                Username = mumbleCredentials.Username,
                Password = mumbleCredentials.Password,
                Tokens = mumbleCredentials.Tokens ?? new string[0],
                CeltVersions = new[] {unchecked ((int) 0x8000000b)},
                Opus = true
            };

            Send(PacketType.Authenticate, authenticate);
        }

        public void Process()
        {
            if (!_tcpClient.Connected)
            {
                ConnectionState = ConnectionStates.Disconnected;
                throw new InvalidOperationException("Not connected.");
            }

            if ((DateTime.Now - _lastSentPing).TotalSeconds > 15)
            {
                Send(PacketType.Ping, new Ping());
                _lastSentPing = DateTime.Now;
            }

            if (!_tcpNetworkStream.DataAvailable)
            {
                return;
            }

            var packetType = (PacketType) IPAddress.NetworkToHostOrder(_tcpReader.ReadInt16());
            switch (packetType)
            {
                case PacketType.Version:
                    _mumbleCallback.VersionCallback(Serializer.DeserializeWithLengthPrefix<Version>(_tcpSslStream,
                        PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.UdpTunnel:
                    var length = IPAddress.NetworkToHostOrder(_tcpReader.ReadInt32());
                    _mumbleCallback.UdpTunnelCallback(_tcpReader.ReadBytes(length));
                    break;
                case PacketType.Authenticate:
                    _mumbleCallback.AuthenticateCallback(
                        Serializer.DeserializeWithLengthPrefix<Authenticate>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.Ping:
                    _mumbleCallback.PingCallback(Serializer.DeserializeWithLengthPrefix<Ping>(_tcpSslStream,
                        PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.Reject:
                    _mumbleCallback.RejectCallback();
                    break;
                case PacketType.ServerSync:
                    _mumbleCallback.ServerSyncCallback(
                        Serializer.DeserializeWithLengthPrefix<ServerSync>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.ChannelRemove:
                    _mumbleCallback.ChannelRemoveCallback(
                        Serializer.DeserializeWithLengthPrefix<ChannelRemove>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.ChannelState:
                    _mumbleCallback.ChannelStateCallback(
                        Serializer.DeserializeWithLengthPrefix<ChannelState>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.UserRemove:
                    _mumbleCallback.UserRemoveCallback(
                        Serializer.DeserializeWithLengthPrefix<UserRemove>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.UserState:
                    _mumbleCallback.UserStateCallback(
                        Serializer.DeserializeWithLengthPrefix<UserState>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.BanList:
                    _mumbleCallback.BanListCallback();
                    break;
                case PacketType.TextMessage:
                    _mumbleCallback.TextMessageCallback(
                        Serializer.DeserializeWithLengthPrefix<TextMessage>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.PermissionDenied:
                    _mumbleCallback.PermissionDeniedCallback();
                    break;
                case PacketType.Acl:
                    _mumbleCallback.AclCallback();
                    break;
                case PacketType.QueryUsers:
                    _mumbleCallback.QueryUsersCallback();
                    break;
                case PacketType.CryptSetup:
                    _mumbleCallback.CryptSetupCallback(
                        Serializer.DeserializeWithLengthPrefix<CryptSetup>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.ContextActionAdd:
                    _mumbleCallback.ContextActionAddCallback(
                        Serializer.DeserializeWithLengthPrefix<ContextActionAdd>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.ContextAction:
                    _mumbleCallback.ContextActionCallback(
                        Serializer.DeserializeWithLengthPrefix<ContextAction>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.UserList:
                    _mumbleCallback.UserListCallback(Serializer.DeserializeWithLengthPrefix<UserList>(_tcpSslStream,
                        PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.VoiceTarget:
                    _mumbleCallback.VoiceTargetCallback();
                    break;
                case PacketType.PermissionQuery:
                    _mumbleCallback.PermissionQueryCallback(
                        Serializer.DeserializeWithLengthPrefix<PermissionQuery>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.CodecVersion:
                    _mumbleCallback.CodecVersionCallback(
                        Serializer.DeserializeWithLengthPrefix<CodecVersion>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.UserStats:
                    _mumbleCallback.UserStatsCallback();
                    break;
                case PacketType.RequestBlob:
                    _mumbleCallback.RequestBlobCallback();
                    break;
                case PacketType.ServerConfig:
                    _mumbleCallback.ServerConfigCallback(
                        Serializer.DeserializeWithLengthPrefix<ServerConfig>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.SuggestConfig:
                    _mumbleCallback.SuggestConfigCallback(
                        Serializer.DeserializeWithLengthPrefix<SuggestConfig>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian));
                    break;
                case PacketType.Empty:
                    _mumbleCallback.EmptyCallback();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Send<T>(PacketType packetType, T packet)
        {
            if (ConnectionState != ConnectionStates.Connecting && ConnectionState != ConnectionStates.Connected)
            {
                throw new InvalidOperationException("Not connected.");
            }

            lock (_tcpSslStream)
            {
                _tcpWriter.Write(IPAddress.HostToNetworkOrder((short) packetType));
                _tcpWriter.Flush();
                Serializer.SerializeWithLengthPrefix(_tcpSslStream, packet, PrefixStyle.Fixed32BigEndian);
                _tcpSslStream.Flush();
                _tcpNetworkStream.Flush();
            }
        }
    }
}