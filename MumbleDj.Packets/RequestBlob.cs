using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public sealed class RequestBlob
    {
        public override string ToString()
        {
            return string.Format("SessionTexture:{0}\nSessionComment:{1}\nChannelDescription:{2}",
                SessionTexture != null ? string.Join(",", SessionTexture) : "null",
                SessionTexture != null ? string.Join(",", SessionComment) : "null",
                ChannelDescription != null ? string.Join(",", ChannelDescription) : "null");
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public UInt32[] SessionTexture;
        [ProtoMember(2)] public UInt32[] SessionComment;
        [ProtoMember(3)] public UInt32[] ChannelDescription;
        // ReSharper restore UnassignedField.Global
    }
}