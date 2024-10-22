using AutoMapper;
using Avhrm.Domains;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;

namespace Avhrm.Application.Server.Features;
public class UpdateWorkReportHandler(IMapper mapper
    , AvhrmDbContext context
    , IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateWorkReportCommand, UpdateWorkReportVm>
{
    public async Task<UpdateWorkReportVm> Handle(UpdateWorkReportCommand request, CancellationToken cancellationToken)
    {
        WorkReport workReport = mapper.Map<WorkReport>(request);

        workReport.LastUpdateDateTime = DateTime.Now;
        workReport.LastUpdateUserId = httpContextAccessor.HttpContext.User.GetUserId();

        context.Update(workReport);

        return new()
        {
            Result = await context.SaveChangesAsync() > 0
        };
    }
}
