using Microsoft.AspNetCore.Mvc;

namespace AmvoxStock.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseApiController : ControllerBase
{

}