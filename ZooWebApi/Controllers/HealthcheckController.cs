using Microsoft.AspNetCore.Mvc;

namespace ZooWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthcheckController : ControllerBase
{
    private readonly ILogger<HealthcheckController> _logger;

    public HealthcheckController(ILogger<HealthcheckController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public ActionResult<string> Get()
    {
        _logger.LogInformation("Health check requested at {Time}", DateTime.UtcNow);
        return "Ok";
    }
}