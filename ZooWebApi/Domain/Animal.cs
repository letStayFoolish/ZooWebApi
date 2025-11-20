using ZooWebApi.Domain.Enumerations;

namespace ZooWebApi.Domain;

public abstract class Animal
{
    public Guid AnimalId { get; set; } = Guid.NewGuid();
    public string  Name { get; set; }
    public string Species { get; set; }
    public AnimalType Type { get; set; }
    public int Hunger { get; set; } = default;
    public abstract double Consume(double amount);
}