using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public sealed class Version
    {
        public override string ToString()
        {
            return string.Format("Version:{0}\nRelease:{1}\nOs:{2}\nOsVersion:{3}", ReleaseVersion, Release, Os,
                OsVersion);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? ReleaseVersion;
        [ProtoMember(2, IsRequired = false)] public string Release;
        [ProtoMember(3, IsRequired = false)] public string Os;
        [ProtoMember(4, IsRequired = false)] public string OsVersion;
        // ReSharper restore UnassignedField.Global
    }
}