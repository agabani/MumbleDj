using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class BanList
    {
        public override string ToString()
        {
            return string.Format("Bans:{0}\nQuery:{1}", Bans != null ? string.Join(",", Bans.ToString()) : "null", Query);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public BanEntry[] Bans;
        [ProtoMember(2, IsRequired = false)] public bool? Query = false;
        // ReSharper restore UnassignedField.Global
    }

    [ProtoContract]
    public class BanEntry
    {
        public override string ToString()
        {
            return string.Format("Address:{0}\nMask:{1}\nName:{2}\nHash:{3}\nReason:{4}\nStart:{5}\nDuration:{6}",
                Address, Mask, Name, Hash, Reason, Start, Duration);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public byte[] Address;
        [ProtoMember(2)] public UInt32 Mask;
        [ProtoMember(3, IsRequired = false)] public string Name;
        [ProtoMember(4, IsRequired = false)] public string Hash;
        [ProtoMember(5, IsRequired = false)] public string Reason;
        [ProtoMember(6, IsRequired = false)] public string Start;
        [ProtoMember(7, IsRequired = false)] public UInt32? Duration;
        // ReSharper restore UnassignedField.Global
    }
}