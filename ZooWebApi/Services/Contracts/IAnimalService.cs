using ZooWebApi.Domain;
using ZooWebApi.Domain.Enumerations;
using ZooWebApi.Dto;

namespace ZooWebApi.Services.Contracts;

public interface IAnimalService
{
    public IEnumerable<AnimalResponse> GetAllAnimals();
    IEnumerable<AnimalResponse> GetAnimalsFilteredByType(AnimalType type);
    void AddAnimal(Animal animal);
    void RemoveAnimal(Guid animalId);
}