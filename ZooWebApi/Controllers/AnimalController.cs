using Microsoft.AspNetCore.Mvc;
using ZooWebApi.Domain.Enumerations;
using ZooWebApi.Services.Contracts;

namespace ZooWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController :ControllerBase
{
    private readonly IAnimalService _animalService;
    private readonly ILogger<AnimalController> _logger;
    
    public AnimalController(IAnimalService animalService, ILogger<AnimalController> logger)
    {
        _animalService = animalService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllAnimals()
    {
        _logger.LogInformation("Animals requested at {Time}", DateTime.UtcNow);
        return Ok(_animalService.GetAllAnimals());
    }

    [HttpGet]
    [Route("type/{type}")]
    public IActionResult GetAnimalsByType(AnimalType type)
    {
        return Ok(_animalService.GetAnimalsFilteredByType(type));
    }
    
}