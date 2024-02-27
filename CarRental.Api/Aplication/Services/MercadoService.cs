using CarRental.Api.Aplication.Interfaces;
using CarRental.Api.Dominio.Repository;
using CarRental.Api.Presentacion.Dtos;

namespace CarRental.Api.Aplication.Services
{
    public class MercadoService : IMercadoService
    {
        readonly IMercadoRepository _mercadoRepository;

        public MercadoService(IMercadoRepository mercadoRepository)
        {
            _mercadoRepository = mercadoRepository;
        }
        public async Task<ResultGeneric<List<MercadoDto>>> GetAllMarkets()
        {
           var  mercados = await _mercadoRepository.GetAll();
            return new ResultGeneric<List<MercadoDto>>()
            {
                Result = mercados,
                Count = mercados.Count
            };
        }

        public async Task<ResultGeneric<List<MercadoDto>>> SearchVehiclesbyMarket(SearchCriteria criteria)
        {
          var mercados = await _mercadoRepository.SearchMarketsByCriteria(criteria);
            return new ResultGeneric<List<MercadoDto>>()
            {
                Result = mercados,
                Count = criteria.Count
            };
        }
    }
}
