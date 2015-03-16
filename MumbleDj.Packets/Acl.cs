using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    sealed public class Acl
    {
        public override String ToString()
        {
            return string.Format("ChannelId:{0}\nInheritAcls:{1}\nGroups:{2}\nAcls:{3}\nQuery:{4}",
                ChannelId, InheritAcls, Groups != null ? string.Join(",", Groups.ToString()) : "null",
                Acls != null ? string.Join(",", Acls.ToString()) : "null", Query);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public UInt32 ChannelId;
        [ProtoMember(2, IsRequired = false)] public bool? InheritAcls = true;
        [ProtoMember(3)] public ChanGroup[] Groups;
        [ProtoMember(4)] public ChanAcl[] Acls;
        [ProtoMember(5, IsRequired = false)] public bool? Query = false;
        // ReSharper restore UnassignedField.Global
    }

    [ProtoContract]
    sealed public class ChanAcl
    {
        public override String ToString()
        {
            return
                string.Format("ApplyHere:{0}\nApplySubs:{1}\nInherited:{2}\nUserId:{3}\nGroup:{4}\nGrant:{5}\nDeny:{6}",
                    ApplyHere, ApplySubs, Inherited, UserId, Group, Grant, Deny);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public bool? ApplyHere = true;
        [ProtoMember(2, IsRequired = false)] public bool? ApplySubs = true;
        [ProtoMember(3, IsRequired = false)] public bool? Inherited = true;
        [ProtoMember(4, IsRequired = false)] public UInt32? UserId;
        [ProtoMember(5, IsRequired = false)] public string Group;
        [ProtoMember(6, IsRequired = false)] public UInt32? Grant;
        [ProtoMember(7, IsRequired = false)] public UInt32? Deny;
        // ReSharper restore UnassignedField.Global
    }

    sealed public class ChanGroup
    {
        public override string ToString()
        {
            return
                string.Format(
                    "Name:{0}\nInherited:{1}\nInherit:{2}\nInheritable:{3}\nAdd:{4}\nRemove:{5}\nInheritedMembers:{6}",
                    Name, Inherited, Inherit, Inheritable, Add != null ? string.Join(",", Add) : "null",
                    Remove != null ? string.Join(",", Remove) : null,
                    InheritedMembers != null ? string.Join(",", InheritedMembers) : "null");
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public string Name;
        [ProtoMember(2, IsRequired = false)] public bool? Inherited = true;
        [ProtoMember(3, IsRequired = false)] public bool? Inherit = true;
        [ProtoMember(4, IsRequired = false)] public bool? Inheritable = true;
        [ProtoMember(5)] public UInt32[] Add;
        [ProtoMember(6)] public UInt32[] Remove;
        [ProtoMember(7)] public UInt32[] InheritedMembers;
        // ReSharper restore UnassignedField.Global
    }
}