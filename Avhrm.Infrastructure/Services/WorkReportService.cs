using AutoMapper;
using Avhrm.Application.Common;
using Avhrm.Application.Contracts;
using Avhrm.Application.Features.WorkingReport.Command.DeleteWorkReport;
using Avhrm.Application.Features.WorkingReport.Command.SaveWorkReport;
using Avhrm.Application.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using Avhrm.Application.Features.WorkingReport.Query.GetWorkReportById;
using Avhrm.Domains;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Infrastructure.Services;

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

    public async Task<List<GetUserWorkingReportByDateVm>> GetWorkingReportByDate(GetUserWorkingReportByDateQuery query, CallContext context = default)
    => mapper.Map<List<GetUserWorkingReportByDateVm>>(
       await dbSet.Where(p => p.PersianDate == PersianCalendarTools.GregorianToPersian(query.Date)
                               && p.CreatorUserId == context.GetUserId())
                  .Include(p => p.WorkType)
                  .ToListAsync());

    public async Task<SaveWorkReportCommand> GetWorkReportById(GetWorkReportByIdQuery query, CallContext context = default)
    => mapper.Map<SaveWorkReportCommand>(await dbSet.Include(p => p.WorkChallenges)
                                                    .FirstOrDefaultAsync(p => p.Id == query.Id));

    public async Task<BaseDto<bool>> InsertWorkReport(SaveWorkReportCommand command, CallContext context = default)
    {
        WorkReport workReport = mapper.Map<WorkReport>(command);

        workReport.WorkChallenges = new HashSet<WorkChallenge>();

        foreach (var workChallengeId in command.WorkChallengesIds)
        {
            WorkChallenge workChallenge = new()
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

        workReport.LastUpdateDateTime = DateTime.Now;

        workReport.LastUpdateUserId = context.GetUserId();

        dbSet.Update(workReport);

        return new()
        {
            Value = await dbContext.SaveChangesAsync() > 0
        };
    }

    public async Task<BaseDto<bool>> DeleteWorkReport(DeleteWorkReportCommand command, CallContext context = default)
    => new()
    {
        Value = dbSet.Where(p => p.Id == command.Id).ExecuteDelete() > 0
    };
}
