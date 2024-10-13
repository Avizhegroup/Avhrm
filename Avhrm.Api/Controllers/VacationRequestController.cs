using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avhrm.Api.Controllers;
public class VacationRequestController(IMediator mediator) : AvhrmBaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromBody] InsertVacationRequestCommand command)
       => Ok(new ApiResponse()
       {
           Successful = true,
           Value = (await mediator.Send<InsertVacationRequestVm>(command))
       });

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
      => Ok(new ApiResponse()
      {
          Successful = true,
          Value = (await mediator.Send<GetVacationRequestsByUserIdVm>(new GetVacationRequestsByUserIdQuery() 
          {
              UserId = HttpContext.User.GetUserId()
          }))
      });

    [HttpGet("[action]")]
    public async Task<IActionResult> Get(GetVacationRequestByIdQuery request)
      => Ok(new ApiResponse()
      {
          Successful = true,
          Value = (await mediator.Send<GetVacationRequestByIdVm>(request))
      });

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateVacationRequestCommand request)
      => Ok(new ApiResponse()
      {
          Successful = true,
          Value = (await mediator.Send<UpdateVacationRequestVm>(request))
      });

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete(DeleteVacationRequestCommand request)
     => Ok(new ApiResponse()
     {
         Successful = true,
         Value = (await mediator.Send<DeleteVacationRequestVm>(request))
     });
}
