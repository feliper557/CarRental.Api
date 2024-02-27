using CarRental.Api.Aplication.Services;
using CarRental.Api.Dominio.Entities;
using CarRental.Api.Model;
using CarRental.Api.Presentacion.Dtos;
using System.Data.Entity;

namespace CarRental.Api.Dominio.Repository
{
    public class MercadoRepository : IMercadoRepository
    {
        private readonly RentalContext _context;
        public MercadoRepository(RentalContext context)
        {
            _context = context;
            
        }
        public async Task<List<MercadoDto>> GetAll()
        {
           var  query = _context.Mercados.Select(x => new MercadoDto
           {
                Id = x.Id,
                Nombre = x.Nombre
            });
            var  result =  query.OrderBy(x => x.Nombre).ToList();
            return result;
        }

        public async Task<List<MercadoDto>> SearchMarketsByCriteria(SearchCriteria criteria)
        {
            var  query = _context.Mercados.Select(x => new MercadoDto
            {
                Id = x.Id,
                Nombre = x.Nombre
            });
            if  (criteria.IdMercado != 0)
            {
                query = query.Where(x => x.Id == criteria.IdMercado);
            }
            criteria.Count = query.Count();
            var  result =  query.OrderBy(x => x.Nombre).ToList();
            return result;
        }
    }
}
