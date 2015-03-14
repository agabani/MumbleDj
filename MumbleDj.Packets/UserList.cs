using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class UserList
    {
        [ProtoMember(1)] public UserListUser[] Users;

        public override string ToString()
        {
            return string.Format("Users:{0}", string.Join(",", Users.ToString()));
        }
    }

    [ProtoContract]
    public class UserListUser
    {
        [ProtoMember(2, IsRequired = false)] public string Name;
        [ProtoMember(1, IsRequired = true)] public UInt32 UserId;

        public override string ToString()
        {
            return string.Format("UserId:{0} Name:{1}", UserId, Name);
        }
    }
}