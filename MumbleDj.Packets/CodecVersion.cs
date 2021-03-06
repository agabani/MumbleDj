﻿using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public sealed class CodecVersion
    {
        public override string ToString()
        {
            return string.Format("Alpha:{0}\nBeta:{1}\nPreferAlpha:{2}\nOpus:{3}", Alpha, Beta, PreferAlpha, Opus);
        }

        // ReSharper disable NotAccessedField.Global
        [ProtoMember(1)] public Int32 Alpha;
        [ProtoMember(2)] public Int32 Beta;
        [ProtoMember(3)] public bool PreferAlpha = true;
        [ProtoMember(4)] public bool? Opus = false;
        // ReSharper restore NotAccessedField.Global
    }
}