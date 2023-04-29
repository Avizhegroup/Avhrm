using ProtoBuf.Grpc;
using System.ServiceModel;

namespace Avhrm.Core.Common;

[ServiceContract]
public interface IBaseContract<T> where T : BaseEntity
{
    [OperationContract]
    Task<List<T>> GetAllForCurrentUser(CallContext context = default, CancellationToken cancellationToken = new());

    [OperationContract]
    Task<bool> InsertInstance(T instance, CallContext context = default, CancellationToken token = new());

    [OperationContract]
    Task<bool> UpdateInstance(T instance, CallContext context = default, CancellationToken token = new());
}
