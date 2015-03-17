using System;
using System.IO;

namespace MumbleDj.TestApp
{
    internal class UdpPacketStream : IDisposable
    {
        private readonly Stream _stream;

        public UdpPacketStream(Stream stream)
        {
            _stream = stream;
        }

        public void Dispose()
        {
            _stream.Dispose();
        }

        public byte ReadByte()
        {
            if (_stream.Position >= _stream.Length)
            {
                throw new EndOfStreamException();
            }

            return (byte) _stream.ReadByte();
        }

        public byte[] ReadBytes(int length)
        {
            var buffer = new byte[length];
            var read = _stream.Read(buffer, 0, length);

            if (length != read)
            {
                return null;
            }

            return buffer;
        }

        public long ReadVarInt64()
        {
            var b = ReadByte();
            var leadingOnes = LeadingOnes(b);

            switch (leadingOnes)
            {
                case 0:
                    return b & 0x7F;
                case 1:
                    return ((b & 0x3F) << 8) | ReadByte();
                case 2:
                    return ((b & 0x1F) << 16) | ReadByte() << 8 | ReadByte();
                case 3:
                    return ((b & 0x0F) << 24) | ReadByte() << 16 | ReadByte() << 8 | ReadByte();
                case 4:
                    if ((b & 4) == 4)
                    {
                        return ReadByte() << 56 | ReadByte() << 48 | ReadByte() << 40 | ReadByte() << 32 |
                               ReadByte() << 16 | ReadByte() << 8 | ReadByte();
                    }
                    return ReadByte() << 24 | ReadByte() << 16 | ReadByte() << 8 | ReadByte();
                case 5:
                    return ~ReadVarInt64();
                case 6:
                case 7:
                case 8:
                    return ~(b & 3);
                default:
                    throw new InvalidDataException();
            }
        }

        public int LeadingOnes(byte value)
        {
            if (0x80 > value)
            {
                return 0;
            }

            if (0xC0 > value)
            {
                return 1;
            }

            if (0xE0 > value)
            {
                return 2;
            }

            if (0xF0 > value)
            {
                return 3;
            }

            if (0xF8 > value)
            {
                return 4;
            }

            if (0xFC > value)
            {
                return 5;
            }

            if (0xFE > value)
            {
                return 6;
            }

            if (0xFF > value)
            {
                return 7;
            }

            return 8;
        }
    }
}