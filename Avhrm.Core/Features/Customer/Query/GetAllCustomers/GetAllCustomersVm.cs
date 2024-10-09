using ProtoBuf;

namespace Avhrm.Application.Features.Customer.Query.GetAllCustomers;

[ProtoContract]
public class GetAllCustomersVm
{
    [ProtoMember(1)]
    public int? Id { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }
}
