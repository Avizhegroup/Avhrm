using ProtoBuf;

namespace Avhrm.Core.Features.Project.Query.GetAllProjects;

[ProtoContract]
public class GetAllProjectsVm
{
    [ProtoMember(1)]
    public int? Id { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }
}
