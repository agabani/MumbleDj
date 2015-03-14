using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class ChannelState
    {
        public override string ToString()
        {
            return
                string.Format(
                    "ChannelId:{0}\nParent:{1}\nName:{2}\nLinks:{3}\nDescription:{4}\nLinksAdd:{5}\nLinksRemove:{6}\nTemporary:{7}\nPosition:{8}",
                    ChannelId, Parent, Name, Links != null ? string.Join(",", Links) : "null", Description,
                    LinksAdd != null ? string.Join(",", LinksAdd) : "null",
                    LinksRemove != null ? string.Join(",", LinksRemove) : "null", Temporary, Position);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public UInt32 ChannelId;
        [ProtoMember(2)] public UInt32 Parent;
        [ProtoMember(3)] public String Name;
        [ProtoMember(4)] public UInt32[] Links;
        [ProtoMember(5)] public String Description;
        [ProtoMember(6)] public UInt32[] LinksAdd;
        [ProtoMember(7)] public UInt32[] LinksRemove;
        [ProtoMember(8, IsRequired = false)] public bool Temporary;
        [ProtoMember(9, IsRequired = false)] public Int32 Position;
        // ReSharper restore UnassignedField.Global
    }
}