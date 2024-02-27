namespace CarRental.Api.Presentacion.Dtos
{
    public class ReservationDTO
    {
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartLocation { get; set; }
        public string ReturnLocation { get; set; }
    }
}
