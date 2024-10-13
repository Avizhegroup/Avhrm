using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avhrm.Api.Controllers;
public class WorkChallengeController(IMediator mediator) : AvhrmBaseController
{
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    => Ok(new ApiResponse()
    {
        Successful = true,
        Value = await mediator.Send<GetAllWorkChallengeVm>(new GetAllWorkChallengeQuery())
    });
}
