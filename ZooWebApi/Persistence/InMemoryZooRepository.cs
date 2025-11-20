using ZooWebApi.Domain;
using ZooWebApi.Domain.Enumerations;

namespace ZooWebApi.Persistence;

public class InMemoryZooRepository : IZooRepository
{
    public List<Animal> Animals { get; set; } = new()
    {
        new Carnivore { Name = "Black Puma", Species = "Wild Cat", Type = AnimalType.Carnivore },
        new Carnivore { Name = "Leo Yo", Species = "Lion", Type = AnimalType.Carnivore },
        new Herbivore { Name = "Zelly", Species = "Zebra", Type = AnimalType.Herbivore },
        new Herbivore { Name = "Cow-go", Species = "Cow", Type = AnimalType.Herbivore },
        new Giraffe { Name = "Giga", Species = "Giraffe", Type = AnimalType.Herbivore },
    };
    
    public double FoodStock { get; set; } = 300.0;
    public int StandardFoodAmount => 10; // in kg.
}