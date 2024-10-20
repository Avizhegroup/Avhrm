using Avhrm.Application.Client.Features;
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

    [HttpPost("[action]")]
    public async Task<IActionResult> Insert(InsertWorkChallengeCommand command)
   => Ok(new ApiResponse()
   {
       Successful = true,
       Value = await mediator.Send<InsertWorkChallengeVm>(command)
   });

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete(DeleteWorkChallengeCommand command)
       => Ok(new ApiResponse()
       {
           Successful = true,
           Value = await mediator.Send<DeleteWorkChallengeVm>(command)
       });
}
