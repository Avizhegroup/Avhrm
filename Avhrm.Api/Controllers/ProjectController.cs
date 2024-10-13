using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avhrm.Api.Controllers;
public class ProjectController(IMediator mediator) : AvhrmBaseController
{
    [HttpGet("[action]")]
    public async Task<IActionResult> Get()
       => Ok(new ApiResponse()
       {
           Successful = true,
           Value = (await mediator.Send<GetAllProjectsVm>(new GetAllProjectsQuery()))
       });
}
