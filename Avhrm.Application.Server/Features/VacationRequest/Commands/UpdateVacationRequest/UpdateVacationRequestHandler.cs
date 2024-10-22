using AutoMapper;
using Avhrm.Domains;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;

namespace Avhrm.Application.Server.Features;
public class UpdateVacationRequestHandler(IMapper mapper
    , AvhrmDbContext context
    , IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateVacationRequestCommand, UpdateVacationRequestVm>
{
    public async Task<UpdateVacationRequestVm> Handle(UpdateVacationRequestCommand request, CancellationToken cancellationToken)
    {
        var data = mapper.Map<VacationRequest>(request);

        data.LastUpdateDateTime = DateTime.Now;

        data.LastUpdateUserId = httpContextAccessor.HttpContext.User.GetUserId();

        context.Update(request);

        return new()
        {
            Result = await context.SaveChangesAsync() > 0
        };
    }
}
