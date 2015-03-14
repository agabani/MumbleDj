using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class UserState
    {
        public override string ToString()
        {
            return
                string.Format(
                    "Session:{0}\nActor:{1}\nName:{2}\nUserId:{3}\nChannelId:{4}\nMute:{5}\nDeaf:{6}\nSuppress:{7}\nSelfMute:{8}\nSelfDeaf:{9}\nTexture:{10}\nPluginContext:{11}\nPluginIdentity:{12}\nComment:{13}\nHash:{14}\nCommentHash:{15}\nTextureHash:{16}\nPrioritySpeaker:{17}\nRecording:{18}"
                    , Session ?? 0, Actor ?? 0, Name, UserId ?? 0, ChannelId ?? 0, Mute ?? false, Deaf ?? false,
                    Suppress ?? false, SelfMute ?? false, SelfDeaf ?? false, Texture,
                    PluginContext, PluginIdentity, Comment, Hash, CommentHash, TextureHash, PrioritySpeaker ?? false,
                    Recording ?? false);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public UInt32? Session;
        [ProtoMember(2)] public UInt32? Actor;
        [ProtoMember(3)] public String Name;
        [ProtoMember(4)] public UInt32? UserId;
        [ProtoMember(5)] public UInt32? ChannelId;
        [ProtoMember(6)] public bool? Mute;
        [ProtoMember(7)] public bool? Deaf;
        [ProtoMember(8)] public bool? Suppress;
        [ProtoMember(9)] public bool? SelfMute;
        [ProtoMember(10)] public bool? SelfDeaf;
        [ProtoMember(11)] public byte[] Texture;
        [ProtoMember(12)] public byte[] PluginContext;
        [ProtoMember(13)] public String PluginIdentity;
        [ProtoMember(14)] public String Comment;
        [ProtoMember(15)] public String Hash;
        [ProtoMember(16)] public byte[] CommentHash;
        [ProtoMember(17)] public byte[] TextureHash;
        [ProtoMember(18)] public bool? PrioritySpeaker;
        [ProtoMember(19)] public bool? Recording;
        // ReSharper restore UnassignedField.Global
    }
}