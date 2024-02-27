using CarRental.Api.Aplication.Services;
using CarRental.Api.Presentacion.Dtos;

namespace CarRental.Api.Aplication.Interfaces
{
    public interface IMercadoService
    {
        Task<ResultGeneric<List<MercadoDto>>> GetAllMarkets();
        Task<ResultGeneric<List<MercadoDto>>> SearchVehiclesbyMarket(SearchCriteria criteria);
    }
}
