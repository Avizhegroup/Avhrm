using Avhrm.Core.Entities;
using ProtoBuf.Grpc;
using System.ServiceModel;

namespace Avhrm.Core.Contracts;

[ServiceContract]
public interface IVacationRequest
{
    [OperationContract]
    Task<VacationRequest> GetAllVacationRequests(CallContext context = default);
}
