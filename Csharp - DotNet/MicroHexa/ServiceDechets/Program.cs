using ServiceDechets.Application.Services;
using ServiceDechets.Domain.Ports;
using ServiceDechets.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// DI Hexagonale
builder.Services.AddScoped<IWasteRepository, WasteRepository>();
builder.Services.AddScoped<IWasteService, WasteService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();