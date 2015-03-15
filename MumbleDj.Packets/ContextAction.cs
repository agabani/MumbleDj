using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class ContextAction
    {
        public override string ToString()
        {
            return string.Format("Session:{0}\nChannelId:{1}\nAction:{2}", Session, ChannelId, Action);
        }

        // ReSharper disable NotAccessedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? Session;
        [ProtoMember(2, IsRequired = false)] public UInt32? ChannelId;
        [ProtoMember(3)] public string Action;
        // ReSharper restore NotAccessedField.Global
    }
}