using ZooWebApi.Domain;
using ZooWebApi.Domain.Enumerations;

namespace ZooWebApi.Services.Contracts;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAllAnimals();
    IEnumerable<Animal> GetAnimalsFilteredByType(AnimalType type);
}