using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public sealed class VoiceTarget
    {
        public override string ToString()
        {
            return string.Format("Id:{0}\nTargets:{1}", Id,
                Targets != null ? string.Join(",", Targets.ToString()) : "null");
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? Id;
        [ProtoMember(2)] public Target[] Targets;
        // ReSharper restore UnassignedField.Global
    }

    [ProtoContract]
    public sealed class Target
    {
        public override string ToString()
        {
            return string.Format("Session:{0}\nChannelId:{1}\nGroup:{2}\nLinks:{3}\nChildren:{4}",
                Session != null ? string.Join(",", Session) : "null",
                ChannelId, Group, Links, Children);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public UInt32[] Session;
        [ProtoMember(2, IsRequired = false)] public UInt32? ChannelId;
        [ProtoMember(3, IsRequired = false)] public string Group;
        [ProtoMember(4, IsRequired = false)] public bool? Links = false;
        [ProtoMember(5, IsRequired = false)] public bool? Children = false;
        // ReSharper restore UnassignedField.Global
    }
}