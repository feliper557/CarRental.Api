using CarRental.Api.Aplication.Services;
using CarRental.Api.Presentacion.Dtos;

namespace CarRental.Api.Dominio.Repository
{
    public interface ILocalidadRepositorio
    {
        Task<List<LocalidadDto>> GetAll();
        Task<List<LocalidadDto>> SearchLocationsByCriteria(SearchCriteria criteria);
    }
}
