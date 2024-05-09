using Avhrm.Core.Features.WorkType.Query.GetAllWorkTypes;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface IProjectService
{
    Task<List<GetAllWorkTypesVm>> GetAllProjects(CallContext callContext = default);
}
