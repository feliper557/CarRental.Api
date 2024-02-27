

namespace CarRental.Api.Aplication.Services
{
    public class SearchCriteria
    {
        public int  startLocation { get; set; }
        public int ReturnLocation { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }   
        public string?  VehicleType { get; set; }
        public int IdMercado { get; set; }
        public  int  Page { get; set; }
        public  int  PageSize { get; set; }
        public int Count { get; set; }



    }
}
