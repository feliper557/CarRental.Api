using CarRental.Api.Dominio.Entities;

namespace CarRental.Api.Presentacion.Dtos
{
    public class LocalidadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }        

        public ICollection<VehiculoDTO> Vehiculos { get; set; }
    }
}
