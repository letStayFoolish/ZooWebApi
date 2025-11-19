using ZooWebApi.Domain;
using ZooWebApi.Domain.Enumerations;
using ZooWebApi.Services.Contracts;

namespace ZooWebApi.Services.Implementations;

public class AnimalService : IAnimalService
{
    public IEnumerable<Animal> GetAllAnimals()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Animal> GetAnimalsFilteredByType(AnimalType type)
    {
        throw new NotImplementedException();
    }
}