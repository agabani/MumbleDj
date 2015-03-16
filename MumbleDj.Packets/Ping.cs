using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    sealed public class Ping
    {
        public override string ToString()
        {
            return
                string.Format(
                    "TimeStamp:{0}\nGood:{1}\nLate:{2}\nLost:{3}\nResync:{4}\nUdpPackets:{5}\nTcpPackets:{6}\nUdpPingAvg:{7}\nUdpPingVar:{8}\nTcpPingAvg:{9}\nTcpPingVar:{10}",
                    TimeStamp, Good, Late, Lost, Resync, UdpPackets, TcpPackets, UdpPingAvg, UdpPingVar, TcpPingAvg,
                    TcpPingVar);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt64? TimeStamp;
        [ProtoMember(2, IsRequired = false)] public UInt32? Good;
        [ProtoMember(3, IsRequired = false)] public UInt32? Late;
        [ProtoMember(4, IsRequired = false)] public UInt32? Lost;
        [ProtoMember(5, IsRequired = false)] public UInt32? Resync;
        [ProtoMember(6, IsRequired = false)] public UInt32? UdpPackets;
        [ProtoMember(7, IsRequired = false)] public UInt32? TcpPackets;
        [ProtoMember(8, IsRequired = false)] public float? UdpPingAvg;
        [ProtoMember(9, IsRequired = false)] public float? UdpPingVar;
        [ProtoMember(10, IsRequired = false)] public float? TcpPingAvg;
        [ProtoMember(11, IsRequired = false)] public float? TcpPingVar;
        // ReSharper restore UnassignedField.Global
    }
}