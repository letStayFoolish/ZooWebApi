namespace ZooWebApi.Domain;

public class Giraffe : Herbivore
{
    public override int Consume(int amount)
    {
        return amount;
    }
}