using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public sealed class TextMessage
    {
        public override string ToString()
        {
            return string.Format("Actor:{0}\nSession:{1}\nChannelId:{2}\nTreeId:{3}\nMessage:{4}", Actor,
                Session != null ? string.Join(",", Session) : "null",
                ChannelId != null ? string.Join(",", ChannelId) : "null",
                TreeId != null ? string.Join(",", TreeId) : "null", Message);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? Actor;
        [ProtoMember(2)] public UInt32[] Session;
        [ProtoMember(3)] public UInt32[] ChannelId;
        [ProtoMember(4)] public UInt32[] TreeId;
        [ProtoMember(5)] public string Message;
        // ReSharper restore UnassignedField.Global
    }
}