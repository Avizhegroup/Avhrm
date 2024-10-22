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

    [HttpGet("[action]")]
    public async Task<IActionResult> GetByDate([FromBody] GetUserWorkingReportByDateQuery command)
    => Ok(new ApiResponse()
    {
        Successful = true,
        Value = await mediator.Send<GetUserWorkingReportByDateVm>(command)
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

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete([FromBody] DeleteWorkReportCommand command)
   => Ok(new ApiResponse()
   {
       Successful = true,
       Value = await mediator.Send<DeleteWorkReportVm>(command)
   });
}
