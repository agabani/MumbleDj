using System;
using MumbleDj.Packets;
using Version = MumbleDj.Packets.Version;

namespace MumbleDj.TestApp
{
    public class MumbleCallback
    {
        public void VersionCallback(Version version)
        {
            Console.WriteLine(version);
        }

        public void UdpTunnelCallback(byte[] packet)
        {
            Console.WriteLine("{0}", packet);
        }

        public void AuthenticateCallback(Authenticate authenticate)
        {
            Console.WriteLine(authenticate);
        }

        public void PingCallback(Ping ping)
        {
            Console.WriteLine(ping);
        }

        public void RejectCallback()
        {
            throw new NotImplementedException();
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

        public void BanListCallback()
        {
            throw new NotImplementedException();
        }

        public void TextMessageCallback(TextMessage textMessage)
        {
            Console.WriteLine(textMessage);
        }

        public void PermissionDeniedCallback()
        {
            throw new NotImplementedException();
        }

        public void AclCallback()
        {
            throw new NotImplementedException();
        }

        public void QueryUsersCallback()
        {
            throw new NotImplementedException();
        }

        public void CryptSetupCallback(CryptSetup cryptSetup)
        {
            Console.WriteLine(cryptSetup);
        }

        public void ContextActionAddCallback(ContextActionAdd contextActionAdd)
        {
            Console.WriteLine(contextActionAdd);
        }

        public void ContextActionCallback(ContextAction contextAction)
        {
            Console.WriteLine(contextAction);
        }

        public void UserListCallback(UserList userList)
        {
            Console.WriteLine(userList);
        }

        public void VoiceTargetCallback()
        {
            throw new NotImplementedException();
        }

        public void PermissionQueryCallback(PermissionQuery permissionQuery)
        {
            Console.WriteLine(permissionQuery);
        }

        public void CodecVersionCallback(CodecVersion codecVersion)
        {
            Console.WriteLine(codecVersion);
        }

        public void UserStatsCallback()
        {
            throw new NotImplementedException();
        }

        public void RequestBlobCallback()
        {
            throw new NotImplementedException();
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