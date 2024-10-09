using ProtoBuf;

namespace Avhrm.Application.Features.WorkType.Query.GetAllWorkTypes;

[ProtoContract]
public class GetAllWorkTypesVm
{
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public string Description { get; set; }

    [ProtoMember(3)]
    public string DepartmentName { get; set; }
}
