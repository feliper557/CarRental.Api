using CarRental.Api.Dominio.Entities;
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
           modelBuilder.Entity<Mercado>().
                ToTable("Mercados").HasKey(x => x.Id);
           modelBuilder.Entity<Localidad>().
                ToTable("Localidades").HasKey(x => x.Id);
            modelBuilder.Entity<Vehiculo>().
                ToTable("Vehiculos").HasKey(x => x.Id);
            modelBuilder.Entity<Vehiculo>().
                Property(x => x.Modelo).HasMaxLength(50)
                       .IsRequired();

            modelBuilder.Entity<Vehiculo>().
                Property(x => x.Marca).HasMaxLength(50)
                       .IsRequired();
            modelBuilder.Entity<Vehiculo>().
                Property(x => x.Capacidad).IsRequired();
            modelBuilder.Entity<Vehiculo>().Property(x => x.Disponible).IsRequired();
            modelBuilder.Entity<Vehiculo>().Property(x => x.LocalidadId).IsRequired();
            modelBuilder.Entity<Vehiculo>().Property(x => x.MercadoId).IsRequired();

            modelBuilder.Entity<Localidad>().
                Property(x => x.Nombre).HasMaxLength(50)
                       .IsRequired();
            modelBuilder.Entity<Mercado>().
                Property(x => x.Nombre).HasMaxLength(50)
                       .IsRequired();
            modelBuilder.Entity<Vehiculo>().
                HasOne(x => x.Localidad)
                .WithMany(x => x.Vehiculos)
                .HasForeignKey(x => x.LocalidadId);
            modelBuilder.Entity<Vehiculo>().
                HasOne(x => x.Mercado)
                .WithMany(x => x.Vehiculos)
                .HasForeignKey(x => x.MercadoId);

            

        }

    }
}
