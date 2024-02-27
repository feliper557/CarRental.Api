namespace CarRental.Api.Dominio.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Capacidad { get; set; }
        public int Disponible { get; set; }
        public int LocalidadId { get; set; }        
        public int MercadoId { get; set; }
        public Localidad Localidad { get; set; }
        public Mercado Mercado { get; set; }
       
    }
}
