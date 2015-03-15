using ProtoBuf;

namespace MumbleDj.Packets
{
    [ProtoContract]
    public class ContextActionModify
    {
        public override string ToString()
        {
            return string.Format("Action:{0}\nText:{1}\nContext:{2}\nOperation:{3}", Action, Text, Context, Operation);
        }

        // ReSharper disable UnassignedField.Global
        [ProtoMember(1)] public string Action;
        [ProtoMember(2, IsRequired = false)] public string Text;
        [ProtoMember(3, IsRequired = false)] public Context? Context;
        [ProtoMember(4, IsRequired = false)] public Operation? Operation;
        // ReSharper restore UnassignedField.Global
    }

    public enum Context : uint
    {
        Server = 0x01,
        Channel = 0x02,
        User = 0x04
    }

    public enum Operation
    {
        Add = 0,
        Remove = 1
    }
}