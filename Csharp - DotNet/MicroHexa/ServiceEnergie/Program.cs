using ServiceEnergie.Application.Services;
using ServiceEnergie.Domain.Ports;
using ServiceEnergie.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// DI Hexagonale
builder.Services.AddScoped<IEnergyRepository, EnergyRepository>();
builder.Services.AddScoped<IEnergyService, EnergyService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
