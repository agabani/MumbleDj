using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class QueryUsers
    {
        public override string ToString()
        {
            return string.Format("Ids:{0}\nNames:{1}", Ids != null ? string.Join(",", Ids) : "null",
                Names != null ? string.Join(",", Names) : "null");
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public UInt32[] Ids;
        [ProtoMember(2)] public string[] Names;
        // ReSharper restore UnassignedField.Global
    }
}