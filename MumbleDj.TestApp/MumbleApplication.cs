using System;
using System.Threading;
using MumbleDj.MumbleNetworkClient;
using MumbleDj.MumbleNetworkClient.Callbacks;
using MumbleDj.MumbleNetworkClient.Models;
using MumbleDj.Packets;
using Version = MumbleDj.Packets.Version;

namespace MumbleDj.TestApp
{
    public class MumbleApplication : IMumbleCallback
    {
        private readonly MumbleClient _mumbleClient;
        private readonly MumbleCredentials _mumbleCredentials;

        public MumbleApplication(MumbleClient mumbleClient, MumbleCredentials mumbleCredentials)
        {
            _mumbleClient = mumbleClient;
            _mumbleCredentials = mumbleCredentials;
        }

        public void VersionCallback(Version version)
        {
        }

        public void UdpTunnelCallback(byte[] packet)
        {
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
            _mumbleClient.Send(PacketType.TextMessage, textMessage);
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
            throw new NotImplementedException();
        }

        public void Run()
        {
            _mumbleClient.Connect(_mumbleCredentials);

            var t = new Thread(a => UpdateLoop(_mumbleClient)) {IsBackground = true};
            t.Start();
        }

        private void UpdateLoop(MumbleClient client)
        {
            while (client.IsConnected)
            {
                client.Process();
            }
        }
    }
}