using ZooWebApi.Domain;
using ZooWebApi.Domain.Enumerations;
using ZooWebApi.Dto;
using ZooWebApi.Persistence;
using ZooWebApi.Services.Contracts;

namespace ZooWebApi.Services.Implementations;

public class ZooSimulationService : IZooSimulationService
{
    private readonly IZooRepository _zooRepository;
    private readonly ILogger<ZooSimulationService> _logger;
    private readonly IAnimalService _animalService;
    private readonly IFoodService _foodService;
    private readonly Random _random = new();

    //Constants make magic numbers readable and adjustable
    private const int HungerIncrease = 7;
    private const double ProbabilityToFeed = 0.3;
    private const double ProbabilityToBirth = 0.1;
    private const double ProbabilityToDie = 0.05;
    private const double FoodPerTick = 10;

    public ZooSimulationService(IZooRepository zooRepository, ILogger<ZooSimulationService> logger,
        IAnimalService animalService, IFoodService foodService)
    {
        _zooRepository = zooRepository;
        _logger = logger;
        _animalService = animalService;
        _foodService = foodService;
    }

    public void SimulateTick()
    {
        _logger.LogInformation("Simulation tick requested at {Time}", DateTime.UtcNow);

        ProcessHunger();
        ProcessFeeding();
        ProcessBirths();
        ProcessDeaths();
    }

    private void ProcessHunger()
    {
        var animalsFromGet = _animalService.GetAllAnimals();

        foreach (AnimalResponse animal in animalsFromGet)
        {
            animal.Hunger = Math.Min(100, animal.Hunger + HungerIncrease);
        }
    }

    private void ProcessFeeding()
    {
        if (_random.NextDouble() < ProbabilityToFeed)
        {
            foreach (var animal in _zooRepository.Animals)
            {
                // Check if we have enough food for this specific animal
                if (_zooRepository.FoodStock >= FoodPerTick)
                {
                    animal.Consume(FoodPerTick); 
                    _zooRepository.FoodStock -= FoodPerTick;
                }
            }
            _logger.LogInformation("Animals were fed.");
        }
    }

    private void ProcessBirths()
    {
        if (_random.NextDouble() < ProbabilityToBirth)
        {
            var newAnimal = new Carnivore
            {
                Name = $"Newborn-{Guid.NewGuid().ToString()[..4]}",
                Species = "New Species",
                Type = AnimalType.Carnivore
            };

            _animalService.AddAnimal(newAnimal);
            _logger.LogInformation("A new animal was born: {Name}", newAnimal.Name);
        }
    }

    private void ProcessDeaths()
    {
        var animalsFromGet = _animalService.GetAllAnimals();

        var animalResponses = animalsFromGet as AnimalResponse[] ?? animalsFromGet.ToArray();
        if (animalResponses.Length > 0 && _random.NextDouble() < ProbabilityToDie)
        {
            int index = _random.Next(animalResponses.Count());
            AnimalResponse animalAtIndex = animalResponses[index];
            _animalService.RemoveAnimal(animalAtIndex.AnimalId);
            _logger.LogWarning("Animal died: {Name}", animalAtIndex.Name);
        }
    }
}