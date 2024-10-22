using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avhrm.Api.Controllers;
public class DepartmentController(IMediator mediator) :AvhrmBaseController
{
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
  => Ok(new ApiResponse()
  {
      Successful = true,
      Value = (await mediator.Send<GetAllDepartmentVm>(new GetAllDepartmentQuery()))
  });
}
