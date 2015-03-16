using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    sealed public class UserState
    {
        public override string ToString()
        {
            return
                string.Format(
                    "Session:{0}\nActor:{1}\nName:{2}\nUserId:{3}\nChannelId:{4}\nMute:{5}\nDeaf:{6}\nSuppress:{7}\nSelfMute:{8}\nSelfDeaf:{9}\nTexture:{10}\nPluginContext:{11}\nPluginIdentity:{12}\nComment:{13}\nHash:{14}\nCommentHash:{15}\nTextureHash:{16}\nPrioritySpeaker:{17}\nRecording:{18}",
                    Session, Actor, Name, UserId, ChannelId, Mute, Deaf, Suppress, SelfMute, SelfDeaf, Texture,
                    PluginContext, PluginIdentity, Comment, Hash, CommentHash, TextureHash, PrioritySpeaker, Recording);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? Session;
        [ProtoMember(2, IsRequired = false)] public UInt32? Actor;
        [ProtoMember(3, IsRequired = false)] public string Name;
        [ProtoMember(4, IsRequired = false)] public UInt32? UserId;
        [ProtoMember(5, IsRequired = false)] public UInt32? ChannelId;
        [ProtoMember(6, IsRequired = false)] public bool? Mute;
        [ProtoMember(7, IsRequired = false)] public bool? Deaf;
        [ProtoMember(8, IsRequired = false)] public bool? Suppress;
        [ProtoMember(9, IsRequired = false)] public bool? SelfMute;
        [ProtoMember(10, IsRequired = false)] public bool? SelfDeaf;
        [ProtoMember(11, IsRequired = false)] public byte[] Texture;
        [ProtoMember(12, IsRequired = false)] public byte[] PluginContext;
        [ProtoMember(13, IsRequired = false)] public string PluginIdentity;
        [ProtoMember(14, IsRequired = false)] public string Comment;
        [ProtoMember(15, IsRequired = false)] public string Hash;
        [ProtoMember(16, IsRequired = false)] public byte[] CommentHash;
        [ProtoMember(17, IsRequired = false)] public byte[] TextureHash;
        [ProtoMember(18, IsRequired = false)] public bool? PrioritySpeaker;
        [ProtoMember(19, IsRequired = false)] public bool? Recording;
        // ReSharper restore UnassignedField.Global
    }
}