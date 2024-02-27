using CarRental.Api.Aplication.Services;
using CarRental.Api.Presentacion.Dtos;

namespace CarRental.Api.Dominio.Repository
{
    public interface IMercadoRepository
    {
        Task<List<MercadoDto>> GetAll();
        Task<List<MercadoDto>> SearchMarketsByCriteria(SearchCriteria criteria);
    }
}
