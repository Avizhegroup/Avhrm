using AutoMapper;
using Avhrm.Domains;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;

namespace Avhrm.Application.Server.Features;
public class InsertWorkReportHandler(IMapper mapper
    , AvhrmDbContext context
    , IHttpContextAccessor httpContextAccessor) : IRequestHandler<InsertWorkReportCommand, InsertWorkReportVm>
{
    public async Task<InsertWorkReportVm> Handle(InsertWorkReportCommand request, CancellationToken cancellationToken)
    {
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

        workReport.PersianDate = PersianCalendarTools.GregorianToPersian(DateTime.Now);

        workReport.CreateDateTime = DateTime.Now;

        workReport.CreatorUserId = httpContextAccessor.HttpContext.User.GetUserId();

        await context.AddAsync(workReport);

        return new()
        {
            Result = await context.SaveChangesAsync() > 0
        };
    }
}
