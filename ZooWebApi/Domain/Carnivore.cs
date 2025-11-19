namespace ZooWebApi.Domain;

public class Carnivore : Animal
{
    public override int Consume(int amount)
    {
        return amount * 3;
    }
}