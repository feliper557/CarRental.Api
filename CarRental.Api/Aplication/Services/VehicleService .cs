using CarRental.Api.Aplication.Interfaces;
using CarRental.Api.Dominio.Repository;
using CarRental.Api.Presentacion.Dtos;
using Org.BouncyCastle.Asn1.Ocsp;

namespace CarRental.Api.Aplication.Services
{
    public class VehicleService : IVehicleService
    {
        readonly IVehiculoRepository _vehicleRepository;

        public VehicleService(IVehiculoRepository  vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<ResultGeneric<List<VehiculoDTO>>> GetAllVehicles(SearchCriteria criteria)
        {

           var vehicles = await _vehicleRepository.GetAll(criteria);
            return new ResultGeneric<List<VehiculoDTO>> {
                Result = vehicles,
                Count = criteria.Count 
            };

        }

       
        public async Task<ResultGeneric<List<VehiculoDTO>>> SearchVehiclesbyCriterial(SearchCriteria criteria)
        {
            var vehicles = await _vehicleRepository.SearchVehiclesbyLocation(criteria);
            return new ResultGeneric<List<VehiculoDTO>>
            {
                Result = vehicles,
                Count = criteria.Count 
            };
        }
        public  VehiculoDTO Buscarautopor()
        {
            var   vehiculo =  _vehicleRepository.Buscarautopor();
            return vehiculo;
        }
    }
}
