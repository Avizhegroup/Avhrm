using Avhrm.Core.Features.Project.Query.GetAllProjects;
using Avhrm.Core.Features.WorkType.Query.GetAllWorkTypes;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface IProjectService
{
    Task<List<GetAllProjectsVm>> GetAllProjects(CallContext callContext = default);
}
