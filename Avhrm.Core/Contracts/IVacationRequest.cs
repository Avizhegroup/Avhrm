using Avhrm.Core.Common;
using Avhrm.Core.Entities;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface IVacationRequest
{
    Task<BaseDto<bool>> InsertVacationRequest(VacationRequest request, CallContext context = default);

    Task<List<VacationRequest>> GetVacationRequests(CallContext context = default);
}
