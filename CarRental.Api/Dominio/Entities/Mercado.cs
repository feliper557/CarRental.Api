namespace CarRental.Api.Dominio.Entities
{
    public class Mercado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
       
        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
