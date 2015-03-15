using System;
using MumbleDj.Packets;
using Version = MumbleDj.Packets.Version;

namespace MumbleDj.MumbleNetworkClient.Callbacks
{
    public class MumbleProxyCallback : IMumbleCallback
    {
        public IMumbleCallback MumbleCallback { get; set; }

        public void VersionCallback(Version version)
        {
            MumbleCallback.VersionCallback(version);
        }

        public void UdpTunnelCallback(byte[] packet)
        {
            MumbleCallback.UdpTunnelCallback(packet);
        }

        public void AuthenticateCallback(Authenticate authenticate)
        {
            MumbleCallback.AuthenticateCallback(authenticate);
        }

        public void PingCallback(Ping ping)
        {
            MumbleCallback.PingCallback(ping);
        }

        public void RejectCallback(Reject reject)
        {
            MumbleCallback.RejectCallback(reject);
        }

        public void ServerSyncCallback(ServerSync serverSync)
        {
            MumbleCallback.ServerSyncCallback(serverSync);
        }

        public void ChannelRemoveCallback(ChannelRemove channelRemove)
        {
            MumbleCallback.ChannelRemoveCallback(channelRemove);
        }

        public void ChannelStateCallback(ChannelState channelState)
        {
            MumbleCallback.ChannelStateCallback(channelState);
        }

        public void UserRemoveCallback(UserRemove userRemove)
        {
            MumbleCallback.UserRemoveCallback(userRemove);
        }

        public void UserStateCallback(UserState userState)
        {
            MumbleCallback.UserStateCallback(userState);
        }

        public void BanListCallback(BanList banList)
        {
            MumbleCallback.BanListCallback(banList);
        }

        public void TextMessageCallback(TextMessage textMessage)
        {
            MumbleCallback.TextMessageCallback(textMessage);
        }

        public void PermissionDeniedCallback(PermissionDenied permissionDenied)
        {
            MumbleCallback.PermissionDeniedCallback(permissionDenied);
        }

        public void AclCallback(Acl acl)
        {
            MumbleCallback.AclCallback(acl);
        }

        public void QueryUsersCallback(QueryUsers queryUsers)
        {
            MumbleCallback.QueryUsersCallback(queryUsers);
        }

        public void CryptSetupCallback(CryptSetup cryptSetup)
        {
            MumbleCallback.CryptSetupCallback(cryptSetup);
        }

        public void ContextActionModifyCallback(ContextActionModify contextActionModify)
        {
            MumbleCallback.ContextActionModifyCallback(contextActionModify);
        }

        public void ContextActionCallback(ContextAction contextAction)
        {
            MumbleCallback.ContextActionCallback(contextAction);
        }

        public void UserListCallback(UserList userList)
        {
            MumbleCallback.UserListCallback(userList);
        }

        public void VoiceTargetCallback(VoiceTarget voiceTarget)
        {
            MumbleCallback.VoiceTargetCallback(voiceTarget);
        }

        public void PermissionQueryCallback(PermissionQuery permissionQuery)
        {
            MumbleCallback.PermissionQueryCallback(permissionQuery);
        }

        public void CodecVersionCallback(CodecVersion codecVersion)
        {
            MumbleCallback.CodecVersionCallback(codecVersion);
        }

        public void UserStatsCallback(UserStats userStats)
        {
            MumbleCallback.UserStatsCallback(userStats);
        }

        public void RequestBlobCallback(RequestBlob requestBlob)
        {
            MumbleCallback.RequestBlobCallback(requestBlob);
        }

        public void ServerConfigCallback(ServerConfig serverConfig)
        {
            MumbleCallback.ServerConfigCallback(serverConfig);
        }

        public void SuggestConfigCallback(SuggestConfig suggestConfig)
        {
            MumbleCallback.SuggestConfigCallback(suggestConfig);
        }

        public void EmptyCallback()
        {
            throw new NotImplementedException();
        }
    }
}