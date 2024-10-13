using AutoMapper;
using Avhrm.Domains;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;

namespace Avhrm.Application.Server.Features;
public class InsertVacationRequestHandler(AvhrmDbContext context
    , IMapper mapper
    , IHttpContextAccessor httpContextAccessor) : IRequestHandler<InsertVacationRequestCommand, InsertVacationRequestVm>
{
    public async Task<InsertVacationRequestVm> Handle(InsertVacationRequestCommand request, CancellationToken cancellationToken)
    {
        var data= mapper.Map<VacationRequest>(request);

        data.IsVerified = false;

        data.CreateDateTime = DateTime.Now;

        data.CreatorUserId = httpContextAccessor.HttpContext.User.GetUserId();

        await context.AddAsync(request);

        return new()
        {
            Result = await context.SaveChangesAsync() > 0
        };
    }
}
