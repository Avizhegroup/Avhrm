using AutoMapper;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;

namespace Avhrm.Application.Server.Features;
public class GetWorkReportByIdHandler (IMapper mapper
    , AvhrmDbContext context
    , IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetWorkReportByIdQuery, GetWorkReportByIdVm>
{
    public async Task<GetWorkReportByIdVm> Handle(GetWorkReportByIdQuery request, CancellationToken cancellationToken)
    => mapper.Map<GetWorkReportByIdVm>((await context.WorkingReports
                                                     .Include(p => p.WorkChallenges)
                                                     .FirstOrDefaultAsync(p => p.Id == request.Id)));
}
