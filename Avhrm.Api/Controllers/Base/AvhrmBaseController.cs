using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Avhrm.Api.Controllers;

[ApiController]
[EnableCors("OpenCors")]
[Route("Avhrm/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class AvhrmBaseController:ControllerBase
{
}
