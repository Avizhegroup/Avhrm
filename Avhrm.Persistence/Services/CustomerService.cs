using AutoMapper;
using Avhrm.Core.Contracts;
using Avhrm.Core.Features.Customer.Query.GetAllCustomers;
using Avhrm.Domains;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Persistence.Services;

public class CustomerService : ICustomerService
{
    private readonly AvhrmDbContext dbContext;
    private readonly IMapper mapper;
    private DbSet<Customer> dbSet;

    public CustomerService(AvhrmDbContext dbContext
        , IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        dbSet = this.dbContext.Customers;
    }

    public async Task<List<GetAllCustomersVm>> GetAllCustomers(CallContext context = default)
    => mapper.Map<List<GetAllCustomersVm>>(await dbSet.ToListAsync());
}
