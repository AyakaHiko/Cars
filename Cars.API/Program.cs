using Cars.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Cars.API.AutoMapperProfiles;
using Cars.API.Data.Entities;
using Cars.API.Repositories;
using Cars.API.Services;
using Cars.Shared.DTO;
using Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddAutoMapper(
    typeof(CarProfile), typeof(ManufacturerProfile));
builder.Services.AddScoped<IRepository<Car>, CarRepository>();
builder.Services.AddScoped<IRepository<Manufacturer>, ManufacturerRepository>();
builder.Services.AddScoped<IService<ManufacturerDto, ManufacturerDetailsDto>, ManufacturerService>();
builder.Services.AddScoped<IService<CarDto, CarDetailsDto>, CarService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarContext>(options =>
    options.UseSqlServer(
        builder.Configuration
            .GetConnectionString("DefaultConnection") ??
        throw new InvalidOperationException("Connection string 'DefaultConnection' not found."))); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;
    await Initializer.Initialize(services);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
