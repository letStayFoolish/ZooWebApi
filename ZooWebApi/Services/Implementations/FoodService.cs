using ZooWebApi.Domain;
using ZooWebApi.Persistence;
using ZooWebApi.Services.Contracts;

namespace ZooWebApi.Services.Implementations;

public class FoodService : IFoodService
{
    private readonly IZooRepository _zooRepository;
    private readonly IAnimalService _animalService;

    public FoodService(IZooRepository zooRepository, IAnimalService animalService)
    {
        _zooRepository = zooRepository;
        _animalService = animalService;
    }
    
    public double GeFoodStock()
    {
        return _zooRepository.FoodStock;
    }

    public void AddFood(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than 0.");
        }
        
        _zooRepository.FoodStock += amount;
    }

    public bool FeedAnimals()
    {
        double animalDailyFoodNeeded = default;
        var animals = _zooRepository.Animals;

        foreach (Animal animal in animals)
        {
            double specificAnimalNeed = animal.Consume(_zooRepository.StandardFoodAmount);
            animalDailyFoodNeeded += specificAnimalNeed;
        }

        if (_zooRepository.FoodStock < animalDailyFoodNeeded)
        {
            return false;
        } 
        
        _zooRepository.FoodStock -= animalDailyFoodNeeded;

        foreach (Animal animal in animals)
        {
            animal.Hunger = 0;
        }
        
        return true;
    }
}