using AutoMapper;
using Avhrm.Application.Contracts;
using Avhrm.Application.Features.Customer.Query.GetAllCustomers;
using Avhrm.Domains;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Infrastructure.Services;

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
