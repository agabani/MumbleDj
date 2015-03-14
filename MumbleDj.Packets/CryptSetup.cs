using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class CryptSetup
    {
        public override string ToString()
        {
            return string.Format("Key:{0}\nClientNonce:{1}\nServerNonce:{2}",
                Key != null ? BitConverter.ToString(Key) : "null",
                ClientNonce != null ? BitConverter.ToString(ClientNonce) : "null",
                ServerNonce != null ? BitConverter.ToString(ServerNonce) : "null");
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public byte[] Key;
        [ProtoMember(2, IsRequired = false)] public byte[] ClientNonce;
        [ProtoMember(3, IsRequired = false)] public byte[] ServerNonce;
        // ReSharper restore UnassignedField.Global
    }
}