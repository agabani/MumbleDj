using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class ServerSync
    {
        public override string ToString()
        {
            return string.Format("Session:{0}\nMaxBandwidth:{1}\nWelcomeText:{2}\nPermissions:{3}", Session, MaxBandwidth,
                WelcomeText, Permissions);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32 Session;
        [ProtoMember(2, IsRequired = false)] public UInt32 MaxBandwidth;
        [ProtoMember(3, IsRequired = false)] public String WelcomeText;
        [ProtoMember(4, IsRequired = false)] public UInt64 Permissions;
        // ReSharper restore UnassignedField.Global
    }
}