using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public sealed class PermissionDenied
    {
        public override string ToString()
        {
            return string.Format("Permission:{0}\nChannelId:{1}\nSession:{2}\nReason:{3}\nDenyType:{4}\nName:{5}",
                Permission, ChannelId, Session, Reason, DenyType, Name);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? Permission;
        [ProtoMember(2, IsRequired = false)] public UInt32? ChannelId;
        [ProtoMember(3, IsRequired = false)] public UInt32? Session;
        [ProtoMember(4, IsRequired = false)] public string Reason;
        [ProtoMember(5, IsRequired = false)] public DenyType? DenyType;
        [ProtoMember(6, IsRequired = false)] public string Name;
        // ReSharper restore UnassignedField.Global
    }

    public enum DenyType
    {
        Text = 0,
        Permission = 1,
        SuperUser = 2,
        ChannelName = 3,
        TextTooLong = 4,
        H9K = 5,
        TemporaryChannel = 6,
        MissingCertificate = 7,
        UserName = 8,
        ChannelFull = 9,
        NestingLimit = 10
    }
}