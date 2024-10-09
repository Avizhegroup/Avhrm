using Avhrm.Application.Common;
using Avhrm.Application.Contracts;
using Avhrm.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Infrastructure.Services;

[Authorize]
public class VacationRequestService : IVacationRequest
{
    private readonly AvhrmDbContext dbContext;
    private DbSet<VacationRequest> dbSet;
    public VacationRequestService(AvhrmDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = this.dbContext.VacationRequests;
    }

    public async Task<BaseDto<bool>> InsertVacationRequest(VacationRequest request, CallContext context = default)
    {
        request.IsVerified = false;

        request.CreateDateTime = DateTime.Now;

        request.CreatorUserId = context.GetUserId();

        await dbSet.AddAsync(request);

        return new()
        {
            Value = await dbContext.SaveChangesAsync() > 0
        };
    }

    public async Task<List<VacationRequest>> GetVacationRequests(CallContext context = default)
    => await dbSet.Where(p => p.CreatorUserId == context.GetUserId()).AsNoTracking().ToListAsync();

    public async Task<VacationRequest> GetVacationRequestById(BaseDto<int> id, CallContext context = default)
    => await dbSet.FirstOrDefaultAsync(p => p.CreatorUserId == context.GetUserId() && p.Id == id.Value);

    public async Task<BaseDto<bool>> UpdateVacationRequest(VacationRequest request, CallContext context = default)
    {
        request.LastUpdateDateTime = DateTime.Now;

        request.LastUpdateUserId = context.GetUserId();

        dbSet.Update(request);

        return new()
        {
            Value = await dbContext.SaveChangesAsync() > 0
        };
    }

    public async Task<BaseDto<bool>> DeleteVacationRequest(VacationRequest request, CallContext context = default)
    {
        dbSet.Remove(request);

        return new()
        {
            Value = await dbContext.SaveChangesAsync() > 0
        };
    }
}
