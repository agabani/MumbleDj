using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MumbleDj.Packets;
using Version = MumbleDj.Packets.Version;

namespace MumbleDj.TestApp
{
    class MumbleProxyCallback : IMumbleCallback
    {
        private IMumbleCallback _mumbleCallback;

        public IMumbleCallback MumbleCallback
        {
            get { return _mumbleCallback; }
            set { _mumbleCallback = value; }
        }


        public void VersionCallback(Version version)
        {
            _mumbleCallback.VersionCallback(version);
        }

        public void UdpTunnelCallback(byte[] packet)
        {
            _mumbleCallback.UdpTunnelCallback(packet);
        }

        public void AuthenticateCallback(Authenticate authenticate)
        {
            _mumbleCallback.AuthenticateCallback(authenticate);
        }

        public void PingCallback(Ping ping)
        {
            _mumbleCallback.PingCallback(ping);
        }

        public void RejectCallback(Reject reject)
        {
            _mumbleCallback.RejectCallback(reject);
        }

        public void ServerSyncCallback(ServerSync serverSync)
        {
            _mumbleCallback.ServerSyncCallback(serverSync);
        }

        public void ChannelRemoveCallback(ChannelRemove channelRemove)
        {
            _mumbleCallback.ChannelRemoveCallback(channelRemove);
        }

        public void ChannelStateCallback(ChannelState channelState)
        {
            _mumbleCallback.ChannelStateCallback(channelState);
        }

        public void UserRemoveCallback(UserRemove userRemove)
        {
            _mumbleCallback.UserRemoveCallback(userRemove);
        }

        public void UserStateCallback(UserState userState)
        {
            _mumbleCallback.UserStateCallback(userState);
        }

        public void BanListCallback(BanList banList)
        {
            _mumbleCallback.BanListCallback(banList);
        }

        public void TextMessageCallback(TextMessage textMessage)
        {
            _mumbleCallback.TextMessageCallback(textMessage);
        }

        public void PermissionDeniedCallback(PermissionDenied permissionDenied)
        {
            _mumbleCallback.PermissionDeniedCallback(permissionDenied);
        }

        public void AclCallback(Acl acl)
        {
            _mumbleCallback.AclCallback(acl);
        }

        public void QueryUsersCallback(QueryUsers queryUsers)
        {
            _mumbleCallback.QueryUsersCallback(queryUsers);
        }

        public void CryptSetupCallback(CryptSetup cryptSetup)
        {
            _mumbleCallback.CryptSetupCallback(cryptSetup);
        }

        public void ContextActionModifyCallback(ContextActionModify contextActionModify)
        {
            _mumbleCallback.ContextActionModifyCallback(contextActionModify);
        }

        public void ContextActionCallback(ContextAction contextAction)
        {
            _mumbleCallback.ContextActionCallback(contextAction);
        }

        public void UserListCallback(UserList userList)
        {
            _mumbleCallback.UserListCallback(userList);
        }

        public void VoiceTargetCallback(VoiceTarget voiceTarget)
        {
            _mumbleCallback.VoiceTargetCallback(voiceTarget);
        }

        public void PermissionQueryCallback(PermissionQuery permissionQuery)
        {
            _mumbleCallback.PermissionQueryCallback(permissionQuery);
        }

        public void CodecVersionCallback(CodecVersion codecVersion)
        {
            _mumbleCallback.CodecVersionCallback(codecVersion);
        }

        public void UserStatsCallback(UserStats userStats)
        {
            _mumbleCallback.UserStatsCallback(userStats);
        }

        public void RequestBlobCallback(RequestBlob requestBlob)
        {
            _mumbleCallback.RequestBlobCallback(requestBlob);
        }

        public void ServerConfigCallback(ServerConfig serverConfig)
        {
            _mumbleCallback.ServerConfigCallback(serverConfig);
        }

        public void SuggestConfigCallback(SuggestConfig suggestConfig)
        {
            _mumbleCallback.SuggestConfigCallback(suggestConfig);
        }

        public void EmptyCallback()
        {
            throw new NotImplementedException();
        }
    }
}
