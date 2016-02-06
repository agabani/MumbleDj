using System;
using MumbleDj.Audio.Models;

namespace MumbleDj.Audio.Utilities
{
    internal class UdpPacketParser
    {
        private readonly UdpPacketStream _udpPacketStream;

        public UdpPacketParser(UdpPacketStream udpPacketStream)
        {
            _udpPacketStream = udpPacketStream;
        }

        public VoicePacket ParseVoicePacket(byte[] packet)
        {
            var voicePacketHeader = ParseVoicePacketHeader(packet, _udpPacketStream);
            var voicePacketAudioData = ParseVoicePacketAudioData(voicePacketHeader, _udpPacketStream);
            var voicePacket = new VoicePacket
            {
                VoicePacketAudioData = voicePacketAudioData,
                VoicePacketHeader = voicePacketHeader
            };
            return voicePacket;
        }

        private static VoicePacketHeader ParseVoicePacketHeader(byte[] packet, UdpPacketStream udpPacketStream)
        {
            var voicePacketHeader = new VoicePacketHeader
            {
                Type = ParseUdpType(packet),
                Flags = ParseUdpTarget(packet),
                Session = (UInt32) udpPacketStream.ReadVarInt64(),
                Sequence = udpPacketStream.ReadVarInt64()
            };
            return voicePacketHeader;
        }

        private static UdpTypes ParseUdpType(byte[] packet)
        {
            return (UdpTypes) (packet[0] >> 5 & 0x7);
        }

        private static UdpTargets ParseUdpTarget(byte[] packet)
        {
            return (UdpTargets) (packet[0] & 0x1F);
        }

        private static VoicePacketAudioData ParseVoicePacketAudioData(VoicePacketHeader voicePacketHeader,
            UdpPacketStream udpPacketStream)
        {
            var voicePacketAudioData = new VoicePacketAudioData();

            switch (voicePacketHeader.Type)
            {
                case UdpTypes.CeltAlpha:
                    throw new NotImplementedException();
                case UdpTypes.Ping:
                    throw new NotImplementedException();
                case UdpTypes.Speex:
                    throw new NotImplementedException();
                case UdpTypes.CeltBeta:
                    throw new NotImplementedException();
                case UdpTypes.Opus:
                    var length = (int) udpPacketStream.ReadVarInt64() & 0x1fff;
                    voicePacketAudioData.Length = length;
                    voicePacketAudioData.Data = udpPacketStream.ReadBytes(length);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return voicePacketAudioData;
        }
    }
}