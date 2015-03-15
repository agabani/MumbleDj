using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class ServerConfig
    {
        public override string ToString()
        {
            return
                string.Format(
                    "MaxBandwidth:{0}\nWelcomeText:{1}\nAllowHtml:{2}\nMessageLength:{3}\nImageMessageLength:{4}",
                    MaxBandwidth, WelcomeText, AllowHtml, MessageLength, ImageMessageLength);
        }

        // ReSharper disable NotAccessedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? MaxBandwidth;
        [ProtoMember(2, IsRequired = false)] public string WelcomeText;
        [ProtoMember(3, IsRequired = false)] public bool? AllowHtml;
        [ProtoMember(4, IsRequired = false)] public UInt32? MessageLength;
        [ProtoMember(5, IsRequired = false)] public UInt32? ImageMessageLength;
        // ReSharper restore NotAccessedField.Global
    }
}