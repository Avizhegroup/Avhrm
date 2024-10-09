using Avhrm.Application.Features.Customer.Query.GetAllCustomers;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Application;

[Service]
public interface ICustomerService
{
    Task<List<GetAllCustomersVm>> GetAllCustomers(CallContext context = default);
}
