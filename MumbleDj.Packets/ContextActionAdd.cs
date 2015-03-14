using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class ContextActionAdd
    {
        public override string ToString()
        {
            return string.Format("Action:{0}\nText:{1}\nContext:{2}", Action, Text, Context);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public String Action;
        [ProtoMember(2)] public String Text;
        [ProtoMember(3, IsRequired = false)] public UInt32 Context;
        // ReSharper restore UnassignedField.Global
    }
}