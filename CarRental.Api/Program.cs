using CarRental.Api.Aplication.Interfaces;
using CarRental.Api.Aplication.Services;
using CarRental.Api.Dominio.Repository;
using CarRental.Api.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<RentalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Rentacar"));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IMercadoService, MercadoService>();
builder.Services.AddScoped<ILocalidadRepositorio,LocalidadRepositorio>();
builder.Services.AddScoped<IVehiculoRepository,VehiculoRepository>();
builder.Services.AddScoped<IMercadoRepository,MercadoRepository>();


builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
