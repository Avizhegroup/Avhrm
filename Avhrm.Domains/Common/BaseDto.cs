using ProtoBuf;

namespace Avhrm.Domains;

[ProtoContract]
public class BaseDto<T>
{
    [ProtoMember(1)]
    public T Value { get; set; }
}
