using Microsoft.EntityFrameworkCore;
using UserService.Models;
using UserService.Data;
using UserService.DTO;
using UserService.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IService<UserDtoReceive, UserDtoSend>, UserServiceClass>();

string connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();