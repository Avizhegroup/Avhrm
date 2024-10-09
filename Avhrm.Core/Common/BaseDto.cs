using ProtoBuf;

namespace Avhrm.Application.Common;

[ProtoContract]
public class BaseDto<T>
{
    [ProtoMember(1)]
    public T Value { get; set; }
}
