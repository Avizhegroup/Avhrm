using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avhrm.Api.Controllers;
public class CustomerController(IMediator mediator) : AvhrmBaseController
{
    [HttpGet("[action]")]
    public async Task<IActionResult> Get()
    => Ok(new ApiResponse()
    {
        Successful = true,
        Value = (await mediator.Send<GetAllCustomersVm>(new GetAllCustomersQuery()))
    });
}
