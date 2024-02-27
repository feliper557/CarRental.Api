using CarRental.Api.Aplication.Interfaces;
using CarRental.Api.Dominio.Repository;
using CarRental.Api.Presentacion.Dtos;

namespace CarRental.Api.Aplication.Services
{
    public class LocationService : ILocationService
    { 
        readonly ILocalidadRepositorio _localidadRepositorio;
        public LocationService(ILocalidadRepositorio localidadRepositorio)
        {
            _localidadRepositorio = localidadRepositorio;
        }
        public async  Task<ResultGeneric<List<LocalidadDto>>> GetAllLocations()
        {
            var locations = await _localidadRepositorio.GetAll();
            return new ResultGeneric<List<LocalidadDto>>
            {
                Result = locations
                
            };
        }

        public async Task<ResultGeneric<List<LocalidadDto>>> SearchLocations(SearchCriteria criteria)
        {
            var  locations = await _localidadRepositorio.SearchLocationsByCriteria(criteria);
            return new ResultGeneric<List<LocalidadDto>>
            {
                Result = locations,
                Count = criteria.Count
            };
        }
    }
}
