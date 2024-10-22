using AutoMapper;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Avhrm.Application.Server.Features;
public class GetWorkReportByDateHandler (IMapper mapper
    , AvhrmDbContext context
    , IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetUserWorkingReportByDateQuery, GetUserWorkingReportByDateVm>
{
    public async Task<GetUserWorkingReportByDateVm> Handle(GetUserWorkingReportByDateQuery request, CancellationToken cancellationToken)
    => new()
    {
       Data  =
        mapper.Map<List<GetUserWorkingReportByDateDto>>(context.WorkingReports.Where(p => p.PersianDate == PersianCalendarTools.GregorianToPersian(request.Date)
                               && p.CreatorUserId == httpContextAccessor.HttpContext.User.GetUserId())
                  .Include(p => p.WorkType))
    };
}
