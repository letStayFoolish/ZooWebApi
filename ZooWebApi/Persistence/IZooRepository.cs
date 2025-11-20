using ZooWebApi.Domain;

namespace ZooWebApi.Persistence;

public interface IZooRepository
{
    public List<Animal> Animals { get; set; }
    public double FoodStock { get; set; }
    public int StandardFoodAmount { get; }
}