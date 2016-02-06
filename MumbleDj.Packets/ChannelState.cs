using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public sealed class ChannelState
    {
        public override string ToString()
        {
            return
                string.Format(
                    "ChannelId:{0}\nParent:{1}\nName:{2}\nLinks:{3}\nDescription:{4}\nLinksAdd:{5}\nLinksRemove:{6}\nTemporary:{7}\nPosition:{8}\nDescriptionHash:{9}",
                    ChannelId, Parent, Name, Links != null ? string.Join(",", Links) : "null", Description,
                    LinksAdd != null ? string.Join(",", LinksAdd) : "null",
                    LinksRemove != null ? string.Join(",", LinksRemove) : "null", Temporary, Position, DescriptionHash);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? ChannelId;
        [ProtoMember(2, IsRequired = false)] public UInt32? Parent;
        [ProtoMember(3, IsRequired = false)] public string Name;
        [ProtoMember(4)] public UInt32[] Links;
        [ProtoMember(5, IsRequired = false)] public string Description;
        [ProtoMember(6)] public UInt32[] LinksAdd;
        [ProtoMember(7)] public UInt32[] LinksRemove;
        [ProtoMember(8, IsRequired = false)] public bool? Temporary;
        [ProtoMember(9, IsRequired = false)] public Int32? Position;
        [ProtoMember(10, IsRequired = false)] public byte[] DescriptionHash;
        // ReSharper restore UnassignedField.Global
    }
}