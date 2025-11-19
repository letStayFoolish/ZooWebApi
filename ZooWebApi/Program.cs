using Serilog;
using System.Text.Json.Serialization;
using ZooWebApi.Persistence;
using ZooWebApi.Services.Contracts;
using ZooWebApi.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container (DI).
builder.Services.AddSingleton<IZooRepository, InMemoryZooRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IAnimalService, AnimalService>();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.WriteTo.Console();
});

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