using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    sealed public class SuggestConfig
    {
        public override string ToString()
        {
            return string.Format("Version:{0}\nPositional:{1}\nPushToTalk:{2}", Version, Positional, PushToTalk);
        }

        // ReSharper disable NotAccessedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? Version;
        [ProtoMember(2, IsRequired = false)] public bool? Positional;
        [ProtoMember(3, IsRequired = false)] public bool? PushToTalk;
        // ReSharper restore NotAccessedField.Global
    }
}