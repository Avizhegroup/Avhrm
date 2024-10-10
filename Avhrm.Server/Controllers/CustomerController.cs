using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avhrm.Api.Controllers;
public class CustomerController(IMediator mediator) : AvhrmBaseController
{
    [HttpGet("[action]")]
    public async Task<IActionResult> Get([FromBody] GetAllCustomersQuery command)
    => Ok(new ApiResponse()
    {
        Successful = true,
        Value = (await mediator.Send<GetAllCustomersVm>(command))
    });
}
