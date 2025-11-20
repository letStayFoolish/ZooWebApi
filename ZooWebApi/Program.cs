using Serilog;
using System.Text.Json.Serialization;
using ZooWebApi.Jobs;
using ZooWebApi.Persistence;
using ZooWebApi.Services.Contracts;
using ZooWebApi.Services.Implementations;
using ZooWebApi.Settings;

var builder = WebApplication.CreateBuilder(args);

//TODO: Option Pattern for storage
builder.Services.AddOptions<ZooSettings>().BindConfiguration(ZooSettings.SectionName)
    .ValidateDataAnnotations() // Checks for [Required], [Range], etc.
    .ValidateOnStart(); // Fails immediately on startup if config is wrong

var zooSettings = builder.Configuration.GetSection(ZooSettings.SectionName).Get<ZooSettings>();

builder.Services.AddOpenApi();
builder.Services.AddControllers()
    .AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<ZooSimulationWorker>();

// Add services to the container (DI).
if (zooSettings?.StorageType == "InMemory")
{
    builder.Services.AddSingleton<IZooRepository, InMemoryZooRepository>();
}
else
{
    // depending on the storage type (which library we chose), use the corresponding repository
}

builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IAnimalService, AnimalService>();

builder.Host.UseSerilog((context, configuration) => { configuration.WriteTo.Console(); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();