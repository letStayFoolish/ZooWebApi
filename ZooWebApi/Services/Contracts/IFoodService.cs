namespace ZooWebApi.Services.Contracts;

public interface IFoodService
{
    public int GeFoodStock(); // in kg
    public void AddFood(int amount); // in kg
    public bool FeedAnimals(); // returns true if food was successfully consumed
}