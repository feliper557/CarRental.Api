using CarRental.Api.Aplication.Services;
using CarRental.Api.Presentacion.Dtos;

namespace CarRental.Api.Aplication.Interfaces
{
    public interface ILocationService
    {
        Task<ResultGeneric<List<LocalidadDto>>> GetAllLocations();
        Task<ResultGeneric<List<LocalidadDto>>> SearchLocations(SearchCriteria criteria);
    }
}
