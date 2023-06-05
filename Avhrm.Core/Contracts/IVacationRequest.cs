using Avhrm.Core.Entities;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;
using System.ServiceModel;

namespace Avhrm.Core.Contracts;

[ServiceContract]
public interface IVacationRequest
{
    [OperationContract]
    Task<bool> InsertVacationRequest(VacationRequest request, CallContext context = default);

    [OperationContract]
    Task<List<VacationRequest>> GetVacationRequests(CallContext context = default);
}
