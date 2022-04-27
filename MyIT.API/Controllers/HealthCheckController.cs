using Microsoft.AspNetCore.Mvc;

namespace MyIT.API.Controllers;

[ApiController]
[Route("healthcheck")]
public class HealthCheckController : Controller
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        return Ok();
    }
}