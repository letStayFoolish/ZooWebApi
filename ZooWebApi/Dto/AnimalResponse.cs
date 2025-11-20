using ZooWebApi.Domain;

namespace ZooWebApi.Dto;

public class AnimalResponse
{
    public Guid AnimalId { get; set; }
    public string  Name { get; set; }
    public string Species { get; set; }
    public string Type { get; set; }
    public int Hunger { get; set; } = default;
}

public static class AnimalExtensions
{
    public static AnimalResponse TodAnimalResponse(this Animal animal)
    {
        return new AnimalResponse()
        {
            AnimalId = animal.AnimalId,
            Name = animal.Name,
            Species = animal.Species,
            Type = animal.Type.ToString(),
        };
    }
}