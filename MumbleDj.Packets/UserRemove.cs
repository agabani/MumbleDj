using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public sealed class UserRemove
    {
        public override string ToString()
        {
            return string.Format("Session:{0}\nActor:{1}\nReason:{2}\nBan:{3}", Session, Actor, Reason, Ban);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public UInt32 Session;
        [ProtoMember(2, IsRequired = false)] public UInt32? Actor;
        [ProtoMember(3, IsRequired = false)] public string Reason;
        [ProtoMember(4, IsRequired = false)] public bool? Ban;
        // ReSharper restore UnassignedField.Global
    }
}