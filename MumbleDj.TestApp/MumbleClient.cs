using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MumbleDj.Packets;
using ProtoBuf;
using Version = MumbleDj.Packets.Version;

namespace MumbleDj.TestApp
{
    public class MumbleClient : IDisposable
    {
        private readonly string _host;
        private readonly int _port;

        private DateTime _lastSentPing = DateTime.MinValue;

        public MumbleClient(string host, int port)
        {
            _host = host;
            _port = port;
        }

        private TcpClient _tcpClient;
        private SslStream _tcpSslStream;
        private NetworkStream _tcpNetworkStream;
        private BinaryReader _tcpReader;
        private BinaryWriter _tcpWriter;

        public void Connect(string username, string password)
        {
            _tcpClient = new TcpClient(_host, _port);
            _tcpNetworkStream = _tcpClient.GetStream();
            _tcpSslStream = new SslStream(_tcpNetworkStream, false, ValidateServerCertificate, null);

            try
            {
                _tcpSslStream.AuthenticateAsClient("localhost");
            }
            catch (Exception exception)
            {
                Trace.TraceError("Exception: {0}", exception.Message);
                if (exception.InnerException != null)
                {
                    Trace.TraceError("Inner exception: {0}", exception.InnerException.Message);
                }
                throw;
            }

            _tcpReader = new BinaryReader(_tcpSslStream);
            _tcpWriter = new BinaryWriter(_tcpSslStream);

            Handshake(username, password, null, null);
        }

        public void Disconnect()
        {
            _tcpClient.Close();
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        void Handshake(string username, string password, string[] tokens, string serverName)
        {
            Version version = new Version
            {
                ReleaseVersion = (1 << 16) | (2 << 8) | (8 & 0xFF),
                Release = "Mumble Dj",
                Os = Environment.OSVersion.ToString(),
                OsVersion = Environment.OSVersion.VersionString
            };

            Send(PacketType.Version, version);

            Authenticate authenticate = new Authenticate
            {
                Username = username,
                Password = password,
                Tokens = new string[0],
                CeltVersions = new int[] { unchecked((int)0x8000000b) },
                Opus = true
            };

            Send(PacketType.Authenticate, authenticate);
        }

        private void Send<T>(PacketType type, T packet)
        {
            lock (_tcpSslStream)
            {
                _tcpWriter.Write(IPAddress.HostToNetworkOrder((short)type));
                _tcpWriter.Flush();

                Serializer.SerializeWithLengthPrefix(_tcpSslStream, packet, PrefixStyle.Fixed32BigEndian);
                _tcpSslStream.Flush();
                _tcpNetworkStream.Flush();
            }
        }

        public void Process()
        {
            if (!_tcpClient.Connected)
            {
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

            lock (_tcpSslStream)
            {
                PacketType type = (PacketType) IPAddress.NetworkToHostOrder(_tcpReader.ReadInt16());
                switch (type)
                {
                    case PacketType.Version:
                        Version version = Serializer.DeserializeWithLengthPrefix<Version>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(version);
                        break;
                    case PacketType.UdpTunnel:
                        var length = IPAddress.NetworkToHostOrder(_tcpReader.ReadInt32());
                        Console.WriteLine("{0}", _tcpReader.ReadBytes(length));
                        break;
                    case PacketType.Authenticate:
                        Authenticate authenticate = Serializer.DeserializeWithLengthPrefix<Authenticate>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(authenticate);
                        break;
                    case PacketType.Ping:
                        Ping ping = Serializer.DeserializeWithLengthPrefix<Ping>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(ping);
                        break;
                    case PacketType.Reject:
                        break;
                    case PacketType.ServerSync:
                        ServerSync serverSync = Serializer.DeserializeWithLengthPrefix<ServerSync>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(serverSync);
                        break;
                    case PacketType.ChannelRemove:
                        ChannelRemove channelRemove =
                            Serializer.DeserializeWithLengthPrefix<ChannelRemove>(_tcpSslStream,
                                PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(channelRemove);
                        break;
                    case PacketType.ChannelState:
                        ChannelState channelState = Serializer.DeserializeWithLengthPrefix<ChannelState>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(channelState);
                        break;
                    case PacketType.UserRemove:
                        UserRemove userRemove = Serializer.DeserializeWithLengthPrefix<UserRemove>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(userRemove);
                        break;
                    case PacketType.UserState:
                        UserState userState = Serializer.DeserializeWithLengthPrefix<UserState>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(userState);
                        break;
                    case PacketType.BanList:
                        break;
                    case PacketType.TextMessage:
                        TextMessage textMessage = Serializer.DeserializeWithLengthPrefix<TextMessage>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(textMessage);
                        break;
                    case PacketType.PermissionDenied:
                        break;
                    case PacketType.Acl:
                        break;
                    case PacketType.QueryUsers:
                        break;
                    case PacketType.CryptSetup:
                        CryptSetup cryptSetup = Serializer.DeserializeWithLengthPrefix<CryptSetup>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(cryptSetup);
                        break;
                    case PacketType.ContextActionAdd:
                        ContextActionAdd contextActionAdd =
                            Serializer.DeserializeWithLengthPrefix<ContextActionAdd>(_tcpSslStream,
                                PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(contextActionAdd);
                        break;
                    case PacketType.ContextAction:
                        ContextAction contextAction =
                            Serializer.DeserializeWithLengthPrefix<ContextAction>(_tcpSslStream,
                                PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(contextAction);
                        break;
                    case PacketType.UserList:
                        UserList userList = Serializer.DeserializeWithLengthPrefix<UserList>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(userList);
                        break;
                    case PacketType.VoiceTarget:
                        break;
                    case PacketType.PermissionQuery:
                        PermissionQuery permissionQuery =
                            Serializer.DeserializeWithLengthPrefix<PermissionQuery>(_tcpSslStream,
                                PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(permissionQuery);
                        break;
                    case PacketType.CodecVersion:
                        CodecVersion codecVersion = Serializer.DeserializeWithLengthPrefix<CodecVersion>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(codecVersion);
                        break;
                    case PacketType.UserStats:
                        break;
                    case PacketType.RequestBlob:
                        break;
                    case PacketType.ServerConfig:
                        ServerConfig serverConfig = Serializer.DeserializeWithLengthPrefix<ServerConfig>(_tcpSslStream,
                            PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(serverConfig);
                        break;
                    case PacketType.SuggestConfig:
                        SuggestConfig suggestConfig =
                            Serializer.DeserializeWithLengthPrefix<SuggestConfig>(_tcpSslStream,
                                PrefixStyle.Fixed32BigEndian);
                        Console.WriteLine(suggestConfig);
                        break;
                    case PacketType.Empty:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Console.WriteLine();
            }
        }

        public void Dispose()
        {
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

            if (_tcpClient.Connected)
            {
                _tcpClient.Close();
            }
        }
    }
}
