using CarRental.Api.Aplication.Interfaces;
using CarRental.Api.Aplication.Services;
using CarRental.Api.Presentacion.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
       

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMercadoService _mercadoService;
        private readonly ILocationService _localidadService;
        private readonly IVehicleService _vehiculoService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMercadoService mercadoService, ILocationService localidadService, IVehicleService vehiculoService)
        {
            _logger = logger;
            _mercadoService = mercadoService;
            _localidadService = localidadService;
            _vehiculoService = vehiculoService;
        }
        [HttpGet]
        [Route("GetAllLocations")]
        public async Task<ResultGeneric<List<LocalidadDto>>> GetAllLocations()
        {
            return await _localidadService.GetAllLocations();
        }

        [HttpPost]
        [Route("SearchLocations")]
        public async Task<ResultGeneric<List<LocalidadDto>>> SearchLocations(SearchCriteria criteria)
        {
            return await _localidadService.SearchLocations(criteria);
        }
        [HttpGet]
        [Route("GetAllMarkets")]
        public async Task<ResultGeneric<List<MercadoDto>>> GetAllMarkets()
        {
            return await _mercadoService.GetAllMarkets();
        }
        [HttpPost]
        [Route("SearchVehiclesbyMarket")]
        public async Task<ResultGeneric<List<MercadoDto>>> SearchVehiclesbyMarket(SearchCriteria criteria)
        {
            return await _mercadoService.SearchVehiclesbyMarket(criteria);
        }
        [HttpPost]
        [Route("GetAllVehicles")]
        public async Task<ResultGeneric<List<VehiculoDTO>>> GetAllVehicles(SearchCriteria criteria)
        {
            return await _vehiculoService.GetAllVehicles(criteria);
        }
        [HttpPost]
        [Route("SearchVehicles")]
        public async Task<ResultGeneric<List<VehiculoDTO>>> SearchVehicles(SearchCriteria criteria)
        {
            return await _vehiculoService.SearchVehiclesbyCriterial(criteria);
        }
        [HttpGet]
        [Route("GetVehicleById")]
        public VehiculoDTO GetVehiculo()
        {
            return _vehiculoService.Buscarautopor();
        }
        
            

        


        
       


        
    }
}