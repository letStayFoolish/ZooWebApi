namespace ZooWebApi.Domain;

public class Giraffe : Herbivore
{
    public override double Consume(double amount)
    {
        return amount;
    }
}