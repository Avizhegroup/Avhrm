using AutoMapper;
using Avhrm.Domains;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Avhrm.Application.Server.Features;
public class InsertWorkReportHandler(IMapper mapper
    , AvhrmDbContext context
    , IHttpContextAccessor httpContextAccessor
    , ILogger<InsertWorkReportHandler> logger) : IRequestHandler<InsertWorkReportCommand, InsertWorkReportVm>
{
    public async Task<InsertWorkReportVm> Handle(InsertWorkReportCommand request, CancellationToken cancellationToken)
    {
        try
        {
            using var transaction = context.Database.BeginTransaction();

            WorkReport workReport = mapper.Map<WorkReport>(request);

            workReport.WorkChallenges = new HashSet<WorkChallenge>();

            foreach (var workChallengeId in request.WorkChallengesIds)
            {
                WorkChallenge workChallenge = new()
                {
                    Id = workChallengeId
                };

                context.WorkChallenges.Attach(workChallenge);

                workReport.WorkChallenges.Add(workChallenge);
            }

            workReport.CreateDateTime = DateTime.Now;

            workReport.CreatorUserId = httpContextAccessor.HttpContext.User.GetUserId();

            await context.AddAsync(workReport, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            var user = await context.Users
                                                 .FirstOrDefaultAsync(p => p.Id == workReport.CreatorUserId, cancellationToken);

            UserPointChangeLog log = new()
            {
                UserId = user.Id,
                CreateDateTime = DateTime.Now,
                CreatorUserId = user.Id,
                BeforePoint = user.Points
            };

            if (PersianCalendarTools.PersianToGregorian(workReport.PersianDate).Date == DateTime.Now.Date)
            {
                user.Points += 10;
            }
            else
            {
                user.Points += 5;
            }

            log.AfterPoint = user.Points;

            context.Update(user);

            await context.SaveChangesAsync(cancellationToken);

            context.Add(log);

            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return new()
            {
                Result = true
            };
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, ex.Message);

            return new()
            {
                Result = false
            };
        }
    }
}
