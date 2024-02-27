using CarRental.Api.Aplication.Services;
using CarRental.Api.Presentacion.Dtos;

namespace CarRental.Api.Aplication.Interfaces
{
    public interface IVehicleService
    {
        Task<ResultGeneric<List<VehiculoDTO>>> GetAllVehicles(SearchCriteria criteria);
        Task<ResultGeneric<List<VehiculoDTO>>> SearchVehiclesbyCriterial(SearchCriteria criteria);

         VehiculoDTO Buscarautopor();
       
    }

  
}
