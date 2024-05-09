using AutoMapper;
using Avhrm.Core.Common;
using Avhrm.Core.Contracts;
using Avhrm.Core.Features.WorkingReport.Command;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using Avhrm.Core.Features.WorkingReport.Query.GetWorkReportById;
using Avhrm.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Persistence.Services;

[Authorize]
public class WorkReportService : IWorkReportService
{
    private readonly AvhrmDbContext dbContext;
    private readonly IMapper mapper;
    private DbSet<WorkReport> dbSet;

    public WorkReportService(AvhrmDbContext dbContext
        , IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        dbSet = this.dbContext.WorkingReports;
    }

    public async Task<List<WorkReport>> GetWorkingReportByDate(GetUserWorkingReportByDateQuery query, CallContext context = default)
        => await dbSet.Where(p => p.PersianDate == query.Date && p.CreatorUserId == context.GetUserId())
                      .ToListAsync();

    public async Task<WorkReport> GetWorkReportById(GetWorkReportByIdQuery query, CallContext context = default)
    => await dbSet.FirstOrDefaultAsync(p => p.Id == query.Id);

    public async Task<BaseDto<bool>> InsertWorkReport(SaveWorkReportCommand command, CallContext context = default)
    {
        WorkReport workReport = mapper.Map<WorkReport>(command);

        foreach (var workChallengeId in command.WorkChallengesIds)
        {
            WorkChallenge workChallenge = new ()
            {
                Id = workChallengeId
            };

            dbContext.WorkChallenges.Attach(workChallenge);

            workReport.WorkChallenges.Add(workChallenge);
        }

        workReport.PersianDate = PersianCalendarTools.GregorianToPersian(DateTime.Now);

        workReport.CreateDateTime = DateTime.Now;

        workReport.CreatorUserId = context.GetUserId();

        await dbSet.AddAsync(workReport);

        return new()
        {
            Value = await dbContext.SaveChangesAsync() > 0
        };
    }

    public async Task<BaseDto<bool>> UpdateWorkReport(SaveWorkReportCommand command, CallContext context = default)
    {
        WorkReport workReport = mapper.Map<WorkReport>(command);

        dbSet.Attach(workReport);

        workReport.WorkChallenges.Clear();

        foreach (var workChallengeId in command.WorkChallengesIds)
        {
            WorkChallenge workChallenge = new()
            {
                Id = workChallengeId
            };

            dbContext.WorkChallenges.Attach(workChallenge);

            workReport.WorkChallenges.Add(workChallenge);
        }

        workReport.LastUpdateDateTime = DateTime.Now;

        workReport.LastUpdateUserId = context.GetUserId();

        dbSet.Update(workReport);

        return new()
        {
            Value = await dbContext.SaveChangesAsync() > 0
        };
    }

    public async Task<BaseDto<bool>> DeleteWorkReport(WorkReport workReport, CallContext context = default)
    {
        dbSet.Remove(workReport);

        return new()
        {
            Value = await dbContext.SaveChangesAsync() > 0
        };
    }
}
