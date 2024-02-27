using CarRental.Api.Aplication.Services;
using CarRental.Api.Presentacion.Dtos;

namespace CarRental.Api.Dominio.Repository
{
    public interface IVehiculoRepository
    {
        Task<List<VehiculoDTO>> GetAll(SearchCriteria criteria);
        Task<List<VehiculoDTO>> SearchVehiclesbyLocation(SearchCriteria criteria);
        Task<List<VehiculoDTO>> SearchVehiclesbyMarket(SearchCriteria criteria);
        VehiculoDTO Buscarautopor();
    }
}
