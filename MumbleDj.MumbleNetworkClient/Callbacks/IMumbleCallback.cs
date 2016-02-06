using MumbleDj.Packets;

namespace MumbleDj.MumbleNetworkClient.Callbacks
{
    public interface IMumbleCallback
    {
        void VersionCallback(Version version);
        void UdpTunnelCallback(byte[] packet);
        void AuthenticateCallback(Authenticate authenticate);
        void PingCallback(Ping ping);
        void RejectCallback(Reject reject);
        void ServerSyncCallback(ServerSync serverSync);
        void ChannelRemoveCallback(ChannelRemove channelRemove);
        void ChannelStateCallback(ChannelState channelState);
        void UserRemoveCallback(UserRemove userRemove);
        void UserStateCallback(UserState userState);
        void BanListCallback(BanList banList);
        void TextMessageCallback(TextMessage textMessage);
        void PermissionDeniedCallback(PermissionDenied permissionDenied);
        void AclCallback(Acl acl);
        void QueryUsersCallback(QueryUsers queryUsers);
        void CryptSetupCallback(CryptSetup cryptSetup);
        void ContextActionModifyCallback(ContextActionModify contextActionModify);
        void ContextActionCallback(ContextAction contextAction);
        void UserListCallback(UserList userList);
        void VoiceTargetCallback(VoiceTarget voiceTarget);
        void PermissionQueryCallback(PermissionQuery permissionQuery);
        void CodecVersionCallback(CodecVersion codecVersion);
        void UserStatsCallback(UserStats userStats);
        void RequestBlobCallback(RequestBlob requestBlob);
        void ServerConfigCallback(ServerConfig serverConfig);
        void SuggestConfigCallback(SuggestConfig suggestConfig);
        void EmptyCallback();
    }
}