using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using Avhrm.Core.Features.WorkingReport.Query.GetWorkReportById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Persistence.Services;

[Authorize]
public class WorkReportService : IWorkReportService
{
    private readonly AvhrmDbContext dbContext;
    private DbSet<WorkReport> dbSet;

    public WorkReportService(AvhrmDbContext dbContext)
    {
        this.dbContext = dbContext;

        dbSet = this.dbContext.WorkingReports;
    }

    public async Task<List<WorkReport>> GetWorkingReportByDate(GetUserWorkingReportByDateQuery query, CallContext context = default)
    => await dbSet.Where(p => p.WorkDayDateTime == query.Date
                                      && p.CreatorUser == context.GetUserId())
                  .ToListAsync();

    public async Task<WorkReport> GetWorkReportById(GetWorkReportByIdQuery query, CallContext context = default)
    => await dbSet.FirstOrDefaultAsync(p=>p.Id == query.Id);
}
