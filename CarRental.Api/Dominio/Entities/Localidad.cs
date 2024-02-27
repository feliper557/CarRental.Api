namespace CarRental.Api.Dominio.Entities
{
    public class Localidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
       
        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
