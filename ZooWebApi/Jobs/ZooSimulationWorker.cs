using ZooWebApi.Domain;
using ZooWebApi.Domain.Enumerations;
using ZooWebApi.Persistence;

namespace ZooWebApi.Jobs;

public class ZooSimulationWorker : BackgroundService
{
    private readonly ILogger<ZooSimulationWorker> _logger;
    private readonly Random _random = new();
    private readonly IServiceScopeFactory _scopeFactory;

    public ZooSimulationWorker(ILogger<ZooSimulationWorker> logger,
        IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var zooRepository = scope.ServiceProvider.GetRequiredService<IZooRepository>();

                try
                {
                    //add some hunger
                    foreach (Animal animal in zooRepository.Animals)
                    {
                        animal.Hunger = Math.Min(100, animal.Hunger + 7);
                    }

                    if (_random.NextDouble() < 0.3)
                    {
                        foreach (Animal zooRepositoryAnimal in zooRepository.Animals)
                        {
                            zooRepositoryAnimal.Consume(10);

                            zooRepository.FoodStock -= 10;
                        }
                    }

                    // Adding new animals
                    if (_random.NextDouble() < 0.1)
                    {
                        zooRepository.Animals.Add(new Carnivore() { Name = "New Carnivore", Species = "New Species", Type = AnimalType.Carnivore});
                    }

                    // Dying animals
                    if (_random.NextDouble() < 0.05 && zooRepository.Animals.Any())
                    {
                        var random = _random.Next(zooRepository.Animals.Count);
                        zooRepository.Animals.RemoveAt(random);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in simulation loop");
                }
            }


            await Task.Delay(5000, stoppingToken);
        }
    }
}