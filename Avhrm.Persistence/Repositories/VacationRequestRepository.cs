using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Persistence.Repositories;

[Authorize]
public class VacationRequestRepository : IVacationRequest
{
    private readonly AvhrmDbContext dbContext;
    private DbSet<VacationRequest> dbSet;
    public VacationRequestRepository(AvhrmDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = this.dbContext.VacationRequest;
    }

    public async Task<bool> InsertVacationRequest(VacationRequest request, CallContext context = default)
    {
        request.CreatorUser = context.GetUserId();

        await dbSet.AddAsync(request);

        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<List<VacationRequest>> GetVacationRequests(CallContext context = default)
    => await dbSet.Where(p=>p.CreatorUser == context.GetUserId()).AsNoTracking().ToListAsync();
}
