using System;
using MumbleDj.Packets;
using Version = MumbleDj.Packets.Version;

namespace MumbleDj.MumbleNetworkClient.Callbacks
{
    internal class ConsoleWriteLineCallback
    {
        public void VersionCallback(Version version)
        {
            Console.WriteLine(version);
        }

        public void UdpTunnelCallback(byte[] packet)
        {
            Console.WriteLine("{0}", BitConverter.ToString(packet).Replace("-", ":"));
        }

        public void AuthenticateCallback(Authenticate authenticate)
        {
            Console.WriteLine(authenticate);
        }

        public void PingCallback(Ping ping)
        {
            Console.WriteLine(ping);
        }

        public void RejectCallback(Reject reject)
        {
            Console.WriteLine(reject);
        }

        public void ServerSyncCallback(ServerSync serverSync)
        {
            Console.WriteLine(serverSync);
        }

        public void ChannelRemoveCallback(ChannelRemove channelRemove)
        {
            Console.WriteLine(channelRemove);
        }

        public void ChannelStateCallback(ChannelState channelState)
        {
            Console.WriteLine(channelState);
        }

        public void UserRemoveCallback(UserRemove userRemove)
        {
            Console.WriteLine(userRemove);
        }

        public void UserStateCallback(UserState userState)
        {
            Console.WriteLine(userState);
        }

        public void BanListCallback(BanList banList)
        {
            Console.WriteLine(banList);
        }

        public void TextMessageCallback(TextMessage textMessage)
        {
            Console.WriteLine(textMessage);
        }

        public void PermissionDeniedCallback(PermissionDenied permissionDenied)
        {
            Console.WriteLine(permissionDenied);
        }

        public void AclCallback(Acl acl)
        {
            Console.WriteLine(acl);
        }

        public void QueryUsersCallback(QueryUsers queryUsers)
        {
            Console.WriteLine(queryUsers);
        }

        public void CryptSetupCallback(CryptSetup cryptSetup)
        {
            Console.WriteLine(cryptSetup);
        }

        public void ContextActionModifyCallback(ContextActionModify contextActionModify)
        {
            Console.WriteLine(contextActionModify);
        }

        public void ContextActionCallback(ContextAction contextAction)
        {
            Console.WriteLine(contextAction);
        }

        public void UserListCallback(UserList userList)
        {
            Console.WriteLine(userList);
        }

        public void VoiceTargetCallback(VoiceTarget voiceTarget)
        {
            Console.WriteLine(voiceTarget);
        }

        public void PermissionQueryCallback(PermissionQuery permissionQuery)
        {
            Console.WriteLine(permissionQuery);
        }

        public void CodecVersionCallback(CodecVersion codecVersion)
        {
            Console.WriteLine(codecVersion);
        }

        public void UserStatsCallback(UserStats userStats)
        {
            Console.WriteLine(userStats);
        }

        public void RequestBlobCallback(RequestBlob requestBlob)
        {
            Console.WriteLine(requestBlob);
        }

        public void ServerConfigCallback(ServerConfig serverConfig)
        {
            Console.WriteLine(serverConfig);
        }

        public void SuggestConfigCallback(SuggestConfig suggestConfig)
        {
            Console.WriteLine(suggestConfig);
        }

        public void EmptyCallback()
        {
            throw new NotImplementedException();
        }
    }
}