using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Persistence.Services;

[Authorize]
public class WorkTypeService : IWorkTypeService
{
    private readonly AvhrmDbContext dbContext;
    private DbSet<WorkType> dbSet;
    public WorkTypeService(AvhrmDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = this.dbContext.WorkTypes;
    }

    public async Task<List<WorkType>> GetWorkType(CallContext context = default)
    => await dbSet.ToListAsync();
}
