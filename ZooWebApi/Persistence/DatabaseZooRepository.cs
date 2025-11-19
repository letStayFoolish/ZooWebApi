using ZooWebApi.Domain;

namespace ZooWebApi.Persistence;

public class DatabaseZooRepository : IZooRepository
{
    //TODO
    public List<Animal> Animals { get; set; }
    public int FoodStock { get; set; }
    public int StandardFoodAmount { get; }
}