using Avhrm.Application.Features.WorkType.Query.GetAllWorkTypes;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Application;

[Service]
public interface IWorkTypeService
{
    Task<List<GetAllWorkTypesVm>> GetWorkTypesByDepartmentId(CallContext context = default);
}
