using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avhrm.Api.Controllers;
public class WorkReportController(IMediator mediator) : AvhrmBaseController
{
    [HttpGet("[action]")]
    public async Task<IActionResult> Get([FromBody] GetWorkReportByIdQuery command)
    => Ok(new ApiResponse()
    {
        Successful = true,
        Value = await mediator.Send<GetWorkReportByIdVm>(command)
    });

    [HttpPost("[action]")]
    public async Task<IActionResult> Insert([FromBody]InsertWorkReportCommand command)
    => Ok(new ApiResponse()
    {
        Successful = true,
        Value = await mediator.Send<InsertWorkReportVm>(command)
    });

    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] UpdateWorkReportCommand command)
   => Ok(new ApiResponse()
   {
       Successful = true,
       Value = await mediator.Send<UpdateWorkReportVm>(command)
   });
}
