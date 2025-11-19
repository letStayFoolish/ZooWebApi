using ZooWebApi.Domain;

namespace ZooWebApi.Persistence;

public class InMemoryZooRepository : IZooRepository
{
    public List<Animal> Animals { get; set; }
    public int FoodStock { get; set; } = 200;
}