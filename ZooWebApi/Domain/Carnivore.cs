namespace ZooWebApi.Domain;

public class Carnivore : Animal
{
    public override double Consume(double amount)
    {
        return amount * 3;
    }
}