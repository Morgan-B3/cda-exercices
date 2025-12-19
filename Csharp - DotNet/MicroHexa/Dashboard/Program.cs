using Dashboard.Application.Services;
using Dashboard.Infrastructure.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpClients
builder.Services.AddHttpClient<IEnergyClient, EnergyHttpClient>(c =>
{
    c.BaseAddress = new Uri("http://localhost:5282");
});

builder.Services.AddHttpClient<IWasteClient, WasteHttpClient>(c =>
{
    c.BaseAddress = new Uri("http://localhost:5038");
});

builder.Services.AddHttpClient<ITransportClient, TransportHttpClient>(c =>
{
    c.BaseAddress = new Uri("http://localhost:5024");
});

// Services
builder.Services.AddScoped<IDashboardService, DashboardService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();