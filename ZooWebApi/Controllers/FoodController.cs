using Microsoft.AspNetCore.Mvc;
using ZooWebApi.Services.Contracts;

namespace ZooWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;
    private readonly ILogger<FoodController> _logger;

    public FoodController(IFoodService foodService, ILogger<FoodController> logger)
    {
        _foodService = foodService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetFoodStock()
    {
        _logger.LogInformation("Food stock requested at {Time}", DateTime.UtcNow);
        return Ok(_foodService.GeFoodStock());
    }

    [HttpPost]
    [Route("add")]
    public IActionResult AddFood(int amount)
    {
        _logger.LogInformation("Food added at {Time}", DateTime.UtcNow);
        _foodService.AddFood(amount);
        return Ok($"Food added: {amount} kg.");
    }

    [HttpPost]
    [Route("feed")]
    public IActionResult FeedAnimals()
    {
        _logger.LogInformation("Feeding animals at {Time}", DateTime.UtcNow);
        return Ok(_foodService.FeedAnimals());
    }
}