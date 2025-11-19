using ZooWebApi.Domain;
using ZooWebApi.Dto;
using ZooWebApi.Persistence;
using ZooWebApi.Services.Contracts;

namespace ZooWebApi.Services.Implementations;

public class FoodService : IFoodService
{
    private readonly IZooRepository _zooRepository;

    public FoodService(IZooRepository zooRepository)
    {
        _zooRepository = zooRepository;
    }
    
    public int GeFoodStock()
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
        int animalDailyFoodNeeded = default;

        foreach (Animal animal in _zooRepository.Animals)
        {
            int specificAnimalNeed = animal.Consume(_zooRepository.StandardFoodAmount);
            animalDailyFoodNeeded += specificAnimalNeed;
        }

        if (_zooRepository.FoodStock < animalDailyFoodNeeded)
        {
            return false;
        } 
        
        _zooRepository.FoodStock -= animalDailyFoodNeeded;

        foreach (Animal animal in _zooRepository.Animals)
        {
            animal.Hunger = 0;
        }
        
        return true;
    }
}