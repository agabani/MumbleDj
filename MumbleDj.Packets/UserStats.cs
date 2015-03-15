using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class UserStats
    {
        public override string ToString()
        {
            return
                string.Format(
                    "Session:{0}\nStatsOnly:{1}\nCertificates:{2}\nFromClient:{3}\nFromServer:{4}\nUdpPackets:{5}\nTcpPackets:{6}\nUdpPingAvg:{7}\nUdpPingVar:{8}\nTcpPingAvg:{9}\nTcpPingVar:{10}\nVersion:{11}\nCeltVersions:{12}\nAddress:{13}\nBandwidth:{14}\nOnlineSecs:{15}\nIdleSecs:{16}\nStrongCertificate:{17}\nOpus:{18}",
                    Session, StatsOnly, Certificates, FromClient, FromServer, UdpPackets, TcpPackets, UdpPingAvg,
                    UdpPingVar, TcpPingAvg, TcpPingVar, Version,
                    CeltVersions != null ? string.Join(",", CeltVersions) : "null", Address, Bandwidth, OnlineSecs,
                    IdleSecs,
                    StrongCertificate, Opus);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? Session;
        [ProtoMember(2, IsRequired = false)] public bool? StatsOnly = false;
        [ProtoMember(3)] public byte[][] Certificates;
        [ProtoMember(4, IsRequired = false)] public Stats FromClient;
        [ProtoMember(5, IsRequired = false)] public Stats FromServer;
        [ProtoMember(6, IsRequired = false)] public UInt32? UdpPackets;
        [ProtoMember(7, IsRequired = false)] public UInt32? TcpPackets;
        [ProtoMember(8, IsRequired = false)] public float? UdpPingAvg;
        [ProtoMember(9, IsRequired = false)] public float? UdpPingVar;
        [ProtoMember(10, IsRequired = false)] public float? TcpPingAvg;
        [ProtoMember(11, IsRequired = false)] public float? TcpPingVar;
        [ProtoMember(12, IsRequired = false)] public Version Version;
        [ProtoMember(13)] public Int32[] CeltVersions;
        [ProtoMember(14, IsRequired = false)] public byte[] Address;
        [ProtoMember(15, IsRequired = false)] public UInt32? Bandwidth;
        [ProtoMember(16, IsRequired = false)] public UInt32? OnlineSecs;
        [ProtoMember(17, IsRequired = false)] public UInt32? IdleSecs;
        [ProtoMember(18, IsRequired = false)] public bool? StrongCertificate = false;
        [ProtoMember(19, IsRequired = false)] public bool? Opus = false;
        // ReSharper restore UnassignedField.Global
    }

    [ProtoContract]
    public class Stats
    {
        public override string ToString()
        {
            return string.Format("Good:{0}\nLate:{1}\nLost:{2}\nResync:{3}", Good, Late, Lost, Resync);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public UInt32? Good;
        [ProtoMember(2, IsRequired = false)] public UInt32? Late;
        [ProtoMember(3, IsRequired = false)] public UInt32? Lost;
        [ProtoMember(4, IsRequired = false)] public UInt32? Resync;
        // ReSharper restore UnassignedField.Global
    }
}