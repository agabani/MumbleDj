using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class TextMessage
    {
        public override string ToString()
        {
            return string.Format("Actor:{0}\nChannelId:{1}\nMessage:{2}\nSession:{3}\nTreeId:{4}", Actor,
                ChannelId != null ? string.Join(",", ChannelId) : "null",
                Message != null ? string.Join(",", Message) : "null",
                Session != null ? string.Join(",", Session) : "null",
                TreeId != null ? string.Join(",", TreeId) : "null");
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32 Actor;
        [ProtoMember(3)] public UInt32[] ChannelId;
        [ProtoMember(5)] public String[] Message;
        [ProtoMember(2)] public UInt32[] Session;
        [ProtoMember(4)] public UInt32[] TreeId;
        // ReSharper restore UnassignedField.Global
    }
}