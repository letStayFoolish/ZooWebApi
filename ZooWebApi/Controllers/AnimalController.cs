using Microsoft.AspNetCore.Mvc;
using ZooWebApi.Domain.Enumerations;
using ZooWebApi.Services.Contracts;

namespace ZooWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController :ControllerBase
{
    private readonly IAnimalService _animalService;
    
    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAllAnimals()
    {
        return Ok(_animalService.GetAllAnimals());
    }

    [HttpGet]
    [Route("type/{type}")]
    public IActionResult GetAnimalsByType(AnimalType type)
    {
        return Ok(_animalService.GetAnimalsFilteredByType(type));
    }
    
}