﻿using Avhrm.Core.Common;
using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using Avhrm.Core.Features.WorkingReport.Query.GetWorkReportById;
using Azure.Core;
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
    {
        try
        {
            return await dbSet.Where(p => p.PersianDate == query.Date
                                        && p.CreatorUser == context.GetUserId())
                      .ToListAsync();
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }

    public async Task<WorkReport> GetWorkReportById(GetWorkReportByIdQuery query, CallContext context = default)
    => await dbSet.FirstOrDefaultAsync(p => p.Id == query.Id);

    public async Task<BaseDto<bool>> InsertWorkReport(WorkReport workReport, CallContext context = default)
    {
        workReport.WorkDayDateTime = PersianCalendarTools.PersianToGregorian(workReport.PersianDate);

        workReport.CreateDateTime = DateTime.Now;

        workReport.CreatorUser = context.GetUserId();

        await dbSet.AddAsync(workReport);

        return new()
        {
            Value = await dbContext.SaveChangesAsync() > 0
        };
    }

    public async Task<BaseDto<bool>> UpdateWorkReport(WorkReport workReport, CallContext context = default)
    {
        workReport.LastUpdateDateTime = DateTime.Now;

        workReport.LastUpdateUser = context.GetUserId();

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