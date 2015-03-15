using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class PermissionQuery
    {
        public override string ToString()
        {
            return string.Format("ChannelId:{0}\nPermissions:{1}\nFlush:{2}", ChannelId, Permissions, Flush);
        }

        // ReSharper disable NotAccessedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? ChannelId;
        [ProtoMember(2, IsRequired = false)] public UInt32? Permissions;
        [ProtoMember(3, IsRequired = false)] public bool? Flush = false;
        // ReSharper restore NotAccessedField.Global
    }
}