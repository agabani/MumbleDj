using System.IO;
using FragLabs.Audio.Codecs;
using MumbleDj.Audio.Utilities;
using MumbleDj.MumbleNetworkClient.Callbacks;
using MumbleDj.Packets;
using NAudio.Wave;

namespace MumbleDj.Audio
{
    public class MumbleAudio : IMumbleCallback
    {
        private readonly BufferedWaveProvider _bufferedWaveProvider;
        private readonly OpusDecoder _decoder;
        private readonly WaveOut _waveOut;

        public MumbleAudio()
        {
            _decoder = OpusDecoder.Create(48000, 1);
            _waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()) {DeviceNumber = 0};
            _bufferedWaveProvider = new BufferedWaveProvider(new WaveFormat(48000, 16, 1));
            _waveOut.Init(_bufferedWaveProvider);
            _waveOut.Play();
        }

        public void UdpTunnelCallback(byte[] packet)
        {
            var udpPacketStream = new UdpPacketStream(new MemoryStream(packet, 1, packet.Length - 1));
            var udpPacketParser = new UdpPacketParser(udpPacketStream);

            var voicePacket = udpPacketParser.ParseVoicePacket(packet);

            int length;
            var buffer = _decoder.Decode(voicePacket.VoicePacketAudioData.Data, voicePacket.VoicePacketAudioData.Length,
                out length);
            _bufferedWaveProvider.AddSamples(buffer, 0, length);
        }

        public void AuthenticateCallback(Authenticate authenticate)
        {
        }

        public void PingCallback(Ping ping)
        {
        }

        public void RejectCallback(Reject reject)
        {
        }

        public void ServerSyncCallback(ServerSync serverSync)
        {
        }

        public void ChannelRemoveCallback(ChannelRemove channelRemove)
        {
        }

        public void ChannelStateCallback(ChannelState channelState)
        {
        }

        public void UserRemoveCallback(UserRemove userRemove)
        {
        }

        public void UserStateCallback(UserState userState)
        {
        }

        public void BanListCallback(BanList banList)
        {
        }

        public void TextMessageCallback(TextMessage textMessage)
        {
        }

        public void PermissionDeniedCallback(PermissionDenied permissionDenied)
        {
        }

        public void AclCallback(Acl acl)
        {
        }

        public void QueryUsersCallback(QueryUsers queryUsers)
        {
        }

        public void CryptSetupCallback(CryptSetup cryptSetup)
        {
        }

        public void ContextActionModifyCallback(ContextActionModify contextActionModify)
        {
        }

        public void ContextActionCallback(ContextAction contextAction)
        {
        }

        public void UserListCallback(UserList userList)
        {
        }

        public void VoiceTargetCallback(VoiceTarget voiceTarget)
        {
        }

        public void PermissionQueryCallback(PermissionQuery permissionQuery)
        {
        }

        public void CodecVersionCallback(CodecVersion codecVersion)
        {
        }

        public void UserStatsCallback(UserStats userStats)
        {
        }

        public void RequestBlobCallback(RequestBlob requestBlob)
        {
        }

        public void ServerConfigCallback(ServerConfig serverConfig)
        {
        }

        public void SuggestConfigCallback(SuggestConfig suggestConfig)
        {
        }

        public void EmptyCallback()
        {
        }

        public void VersionCallback(Version version)
        {
        }
    }
}