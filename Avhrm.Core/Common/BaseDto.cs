using ProtoBuf;

namespace Avhrm.Core.Common;

[ProtoContract]
public class BaseDto<T>
{
    [ProtoMember(1)]
    public T Value { get; set; }
}
