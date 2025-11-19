using ZooWebApi.Domain;

namespace ZooWebApi.Persistence;

public interface IZooRepository
{
    public List<Animal> Animals { get; set; }
    public int FoodStock { get; set; }
    public int StandardFoodAmount { get; }
}