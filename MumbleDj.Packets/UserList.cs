using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class UserList
    {
        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public User[] Users;
        // ReSharper restore UnassignedField.Global
        public override string ToString()
        {
            return string.Format("Users:{0}", Users != null ? string.Join(",", Users.ToString()) : "null");
        }
    }

    [ProtoContract]
    public class User
    {
        public override string ToString()
        {
            return string.Format("UserId:{0}\nName:{1}\nLastSeen:{2}\nLastChannel:{3}", UserId, Name, LastSeen,
                LastChannel);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public UInt32 UserId;
        [ProtoMember(2, IsRequired = false)] public string Name;
        [ProtoMember(3, IsRequired = false)] public string LastSeen;
        [ProtoMember(4, IsRequired = false)] public UInt32? LastChannel;
        // ReSharper restore UnassignedField.Global
    }
}