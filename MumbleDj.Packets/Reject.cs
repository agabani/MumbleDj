using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public sealed class Reject
    {
        public override string ToString()
        {
            return string.Format("Type:{0}\nReason:{1}", Type, Reason);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1, IsRequired = false)] public RejectType? Type;
        [ProtoMember(2, IsRequired = false)] public string Reason;
        // ReSharper restore UnassignedField.Global
    }

    public enum RejectType
    {
        None = 0,
        WrongVersion = 1,
        InvalidUsername = 2,
        WrongUserPw = 3,
        WrongServerPw = 4,
        UsernameInUse = 5,
        ServerFull = 6,
        NoCertificate = 7,
        AuthenticatorFail = 8
    }
}