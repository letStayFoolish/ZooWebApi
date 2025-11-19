namespace ZooWebApi.Dto;

public class AnimalResponse
{
    public string  Name { get; set; }
    public string Species { get; set; }
    public string Type { get; set; }
    public int Hunger { get; set; } = default;
}