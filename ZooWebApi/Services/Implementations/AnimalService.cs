using ZooWebApi.Domain.Enumerations;
using ZooWebApi.Persistence;
using ZooWebApi.Services.Contracts;
using ZooWebApi.Dto;

namespace ZooWebApi.Services.Implementations;

public class AnimalService : IAnimalService
{
    private readonly IZooRepository _zooRepository;
    
    public AnimalService(IZooRepository zooRepository)
    {
        _zooRepository = zooRepository;
    }
    public IEnumerable<AnimalResponse> GetAllAnimals()
    {
        return _zooRepository.Animals.Select(a => a.TodAnimalResponse());
    }

    public IEnumerable<AnimalResponse> GetAnimalsFilteredByType(AnimalType type)
    {
        return _zooRepository.Animals
            .Where(a => a.Type == type)
            .Select(a => a.TodAnimalResponse()); 
    }
}

