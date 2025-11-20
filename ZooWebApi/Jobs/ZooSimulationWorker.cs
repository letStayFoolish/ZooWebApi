using ZooWebApi.Persistence;
using ZooWebApi.Services.Contracts;

namespace ZooWebApi.Jobs;

public class ZooSimulationWorker : BackgroundService
{
    private readonly ILogger<ZooSimulationWorker> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly PeriodicTimer _timer;

    public ZooSimulationWorker(ILogger<ZooSimulationWorker> logger,
        IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Zoo Simulation Worker started.");
        try
        {
            while (await _timer.WaitForNextTickAsync(stoppingToken))
            {
                await RunSimulationTick();
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Zoo Simulation Worker is stopping.");
        }
    }

    private async Task RunSimulationTick()
    {
        //Create a scope for every tick to ensure we get fresh scoped services
        using var scope = _scopeFactory.CreateScope();
        var simulationService = scope.ServiceProvider.GetRequiredService<IZooSimulationService>();

        try
        {
            simulationService.SimulateTick();
        }
        catch (Exception e)
        {
            //Don't let a crash in logic kill the entire BackgroundService loop.
            _logger.LogError(e, "Error occurred during simulation tick.");
        }
    }
}