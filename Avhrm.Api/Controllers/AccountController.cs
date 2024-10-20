using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Avhrm.Api.Controllers;
public class AccountController(IMediator mediator) : AvhrmBaseController
{
    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<IActionResult> AuthenticateByPassword([FromBody] GetUserLoginQuery command)
    => Ok(new ApiResponse()
    {
        Successful = true,
        Value = (await mediator.Send<GetUserLoginVm>(command))
    });

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    => Ok(new ApiResponse()
    {
        Successful = true,
        Value = (await mediator.Send<GetAllUsersVm>(new GetAllUsersQuery()))
    });

    [HttpGet("[action]")]
    public async Task<IActionResult> Get(GetUserByUsernameQuery command)
   => Ok(new ApiResponse()
   {
       Successful = true,
       Value = (await mediator.Send<GetUserByUsernameVm>(new GetUserByUsernameQuery()))
   });
}
