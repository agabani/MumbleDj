using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public sealed class ChannelRemove
    {
        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public UInt32 ChannelId;
        // ReSharper restore UnassignedField.Global
        public override string ToString()
        {
            return string.Format("ChannelId:{0}", ChannelId);
        }
    }
}