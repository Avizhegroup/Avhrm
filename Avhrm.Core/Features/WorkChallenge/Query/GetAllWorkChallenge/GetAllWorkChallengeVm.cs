using ProtoBuf;

namespace Avhrm.Application.Features.WorkChallenge.Query.GetAllWorkChallenge;

[ProtoContract]
public class GetAllWorkChallengeVm
{
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public string Description { get; set; }

    [ProtoMember(3)]
    public int DepartmentId { get; set; }

    [ProtoMember(4)]
    public string DepartmentName { get; set; }
}
