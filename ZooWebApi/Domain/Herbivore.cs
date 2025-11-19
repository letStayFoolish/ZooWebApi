namespace ZooWebApi.Domain;

public class Herbivore : Animal
{
    public override int Consume(int amount)
    {
        return amount / 2;
    }
}