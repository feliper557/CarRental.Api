using CarRental.Api.Dominio.Entities;
using Microsoft.AspNetCore.Components.Routing;

namespace CarRental.Api.Presentacion.Dtos
{
    public class VehiculoDTO
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Capacidad { get; set; }
        public int Disponible { get; set; }
        public int LocalidadId { get; set; }
        public LocalidadDto Localidad { get; set; }
        public int MercadoId { get; set; }
        public MercadoDto Mercado { get; set; }

    }
}
