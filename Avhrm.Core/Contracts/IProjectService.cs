using Avhrm.Application.Features.Project.Query.GetAllProjects;
using Avhrm.Application.Features.WorkType.Query.GetAllWorkTypes;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Application;

[Service]
public interface IProjectService
{
    Task<List<GetAllProjectsVm>> GetAllProjects(CallContext callContext = default);
}
