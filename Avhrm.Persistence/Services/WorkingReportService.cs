using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Persistence.Services;

[Authorize]
public class WorkingReportService : IWorkingReportService
{
    private readonly AvhrmDbContext dbContext;
    private DbSet<WorkingReport> dbSet;

    public WorkingReportService(AvhrmDbContext dbContext)
    {
        this.dbContext = dbContext;

        dbSet = this.dbContext.WorkingReports;
    }

    public async Task<List<WorkingReport>> GetWorkingReportByDate(GetUserWorkingReportByDateQuery query, CallContext context = default)
    => await dbSet.Where(p => p.WorkDayDateTime == query.Date
                                      && p.CreatorUser == context.GetUserId())
                  .ToListAsync();
}
