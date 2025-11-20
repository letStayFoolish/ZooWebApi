namespace ZooWebApi.Domain;

public class Herbivore : Animal
{
    public override double Consume(double amount)
    {
        return amount / 2;
    }
}