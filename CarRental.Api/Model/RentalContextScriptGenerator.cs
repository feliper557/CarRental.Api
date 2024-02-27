public class RentalContextScriptGenerator
{
    public string GenerateScript()
    {
        var script = @"using CarRental.Api.Dominio.Entities;
using Microsoft.EntityFrameworkCore;


namespace CarRental.Api.Model
{
    public class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> options)
            : base(options)
        {
        }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Localidad>().HasData(
                new Localidad { Id = 1, Nombre = ""Bogotá"", Ciudad = ""Bogotá"" },
                new Localidad { Id = 2, Nombre = ""Medellín"", Ciudad = ""Medellín"" },
                new Localidad { Id = 3, Nombre = ""Cali"", Ciudad = ""Cali"" }
            );

            modelBuilder.Entity<Mercado>().HasData(
                new Mercado { Id = 1, Nombre = ""Norte"" },
                new Mercado { Id = 2, Nombre = ""Sur"" },
                new Mercado { Id = 3, Nombre = ""Oriente"" },
                new Mercado { Id = 4, Nombre = ""Occidente"" }
            );

            modelBuilder.Entity<Vehiculo>().HasData(
                new Vehiculo { Id = 1, Modelo = ""Sedan"", Marca = ""Chevrolet"", Capacidad = 4, Disponible = true, LocalidadId = 1, MercadoId = 1 },
                new Vehiculo { Id = 2, Modelo = ""Sedan"", Marca = ""Mazda"", Capacidad = 4, Disponible = false, LocalidadId = 2, MercadoId = 1 },
                new Vehiculo { Id = 3, Modelo = ""Camioneta"", Marca = ""Chevrolet"", Capacidad = 4, Disponible = true, LocalidadId = 3, MercadoId = 3 },
                new Vehiculo { Id = 4, Modelo = ""Coope"", Marca = ""Mazda"", Capacidad = 4, Disponible = true, LocalidadId = 1, MercadoId = 2 },
                new Vehiculo { Id = 5, Modelo = ""Camioneta"", Marca = ""Nissan"", Capacidad = 4, Disponible = true, LocalidadId = 2, MercadoId = 3 },
                new Vehiculo { Id = 6, Modelo = ""Sedan"", Marca = ""Chevrolet"", Capacidad = 4, Disponible = true, LocalidadId = 3, MercadoId = 4 },
                new Vehiculo { Id = 7, Modelo = ""Sedan"", Marca = ""Nissan"", Capacidad = 4, Disponible = true, LocalidadId = 1, MercadoId = 4 },
                new Vehiculo { Id = 8, Modelo = ""Sedan"", Marca = ""Toyota"", Capacidad = 4, Disponible = true, LocalidadId = 2, MercadoId = 2 },
                new Vehiculo { Id = 9, Modelo = ""Sedan"", Marca = ""Renault"", Capacidad = 4, Disponible = false, LocalidadId = 3, MercadoId = 1 }
            );
        }
    }
}
";
        return script;
    }
}
