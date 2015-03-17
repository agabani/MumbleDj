using System;

namespace MumbleDj.Audio.Models
{
    internal class VoicePacketHeader
    {
        public UdpTargets Flags;
        public Int64 Sequence;
        public UInt32 Session;
        public UdpTypes Type;
    }
}