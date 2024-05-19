using Avhrm.Core.Features.Customer.Query.GetAllCustomers;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface ICustomerService
{
    Task<List<GetAllCustomersVm>> GetAllCustomers(CallContext context = default);
}
