using ZooWebApi.Domain;
using ZooWebApi.Domain.Enumerations;
using ZooWebApi.Persistence;
using ZooWebApi.Services.Contracts;

namespace ZooWebApi.Services.Implementations;

public class AnimalService : IAnimalService
{
    private readonly IZooRepository _zooRepository;
    
    public AnimalService(IZooRepository zooRepository)
    {
        _zooRepository = zooRepository;
    }
    public IEnumerable<Animal> GetAllAnimals()
    {
        //TODO: it would be better to return a DTO instead of the domain model
        return _zooRepository.Animals;
    }

    public IEnumerable<Animal> GetAnimalsFilteredByType(AnimalType type)
    {
        return _zooRepository.Animals.Where(a => a.Type == type); 
    }
}