using System;
using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class Authenticate
    {
        public override string ToString()
        {
            return string.Format("Username:{0}\nPassword:{1}\nTokens:{2}\nCeltVersion:{3}\nOpus:{4}", Username, Password,
                Tokens != null ? string.Join(",", Tokens) : "null",
                CeltVersions != null ? string.Join(",", CeltVersions) : "null", Opus);
        }

        // ReSharper disable NotAccessedField.Global
        [ProtoMember(1, IsRequired = false)] public string Username;
        [ProtoMember(2, IsRequired = false)] public string Password;
        [ProtoMember(3)] public string[] Tokens;
        [ProtoMember(4)] public Int32[] CeltVersions;
        [ProtoMember(5, IsRequired = false)] public bool? Opus = false;
        // ReSharper restore NotAccessedField.Global
    }
}