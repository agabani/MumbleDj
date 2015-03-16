using System;
using System.Collections.Generic;
using MumbleDj.Packets;
using Version = MumbleDj.Packets.Version;

namespace MumbleDj.MumbleNetworkClient.Callbacks
{
    public class MumbleCallbackRouter : IMumbleCallback
    {
        private readonly ICollection<IMumbleCallback> _mumbleCallbacks;

        public MumbleCallbackRouter() : this(new List<IMumbleCallback>())
        {
        }

        public MumbleCallbackRouter(ICollection<IMumbleCallback> mumbleCallbacks)
        {
            _mumbleCallbacks = mumbleCallbacks;
        }

        public void VersionCallback(Version version)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.VersionCallback(version);
            }
        }

        public void UdpTunnelCallback(byte[] packet)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.UdpTunnelCallback(packet);
            }
        }

        public void AuthenticateCallback(Authenticate authenticate)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.AuthenticateCallback(authenticate);
            }
        }

        public void PingCallback(Ping ping)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.PingCallback(ping);
            }
        }

        public void RejectCallback(Reject reject)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.RejectCallback(reject);
            }
        }

        public void ServerSyncCallback(ServerSync serverSync)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.ServerSyncCallback(serverSync);
            }
        }

        public void ChannelRemoveCallback(ChannelRemove channelRemove)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.ChannelRemoveCallback(channelRemove);
            }
        }

        public void ChannelStateCallback(ChannelState channelState)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.ChannelStateCallback(channelState);
            }
        }

        public void UserRemoveCallback(UserRemove userRemove)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.UserRemoveCallback(userRemove);
            }
        }

        public void UserStateCallback(UserState userState)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.UserStateCallback(userState);
            }
        }

        public void BanListCallback(BanList banList)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.BanListCallback(banList);
            }
        }

        public void TextMessageCallback(TextMessage textMessage)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.TextMessageCallback(textMessage);
            }
        }

        public void PermissionDeniedCallback(PermissionDenied permissionDenied)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.PermissionDeniedCallback(permissionDenied);
            }
        }

        public void AclCallback(Acl acl)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.AclCallback(acl);
            }
        }

        public void QueryUsersCallback(QueryUsers queryUsers)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.QueryUsersCallback(queryUsers);
            }
        }

        public void CryptSetupCallback(CryptSetup cryptSetup)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.CryptSetupCallback(cryptSetup);
            }
        }

        public void ContextActionModifyCallback(ContextActionModify contextActionModify)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.ContextActionModifyCallback(contextActionModify);
            }
        }

        public void ContextActionCallback(ContextAction contextAction)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.ContextActionCallback(contextAction);
            }
        }

        public void UserListCallback(UserList userList)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.UserListCallback(userList);
            }
        }

        public void VoiceTargetCallback(VoiceTarget voiceTarget)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.VoiceTargetCallback(voiceTarget);
            }
        }

        public void PermissionQueryCallback(PermissionQuery permissionQuery)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.PermissionQueryCallback(permissionQuery);
            }
        }

        public void CodecVersionCallback(CodecVersion codecVersion)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.CodecVersionCallback(codecVersion);
            }
        }

        public void UserStatsCallback(UserStats userStats)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.UserStatsCallback(userStats);
            }
        }

        public void RequestBlobCallback(RequestBlob requestBlob)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.RequestBlobCallback(requestBlob);
            }
        }

        public void ServerConfigCallback(ServerConfig serverConfig)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.ServerConfigCallback(serverConfig);
            }
        }

        public void SuggestConfigCallback(SuggestConfig suggestConfig)
        {
            foreach (var mumbleCallback in _mumbleCallbacks)
            {
                mumbleCallback.SuggestConfigCallback(suggestConfig);
            }
        }

        public void EmptyCallback()
        {
            throw new NotImplementedException();
        }

        public void Register(IMumbleCallback mumbleCallback)
        {
            _mumbleCallbacks.Add(mumbleCallback);
        }
    }
}