using Avhrm.Core.Entities;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface IWorkTypeService
{
    Task<List<WorkType>> GetWorkType(CallContext context = default);
}
