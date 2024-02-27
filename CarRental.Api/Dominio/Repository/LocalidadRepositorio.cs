
using CarRental.Api.Aplication.Services;
using CarRental.Api.Model;
using CarRental.Api.Presentacion.Dtos;
using System.Data.Entity;

namespace CarRental.Api.Dominio.Repository
{
    public class LocalidadRepositorio : ILocalidadRepositorio
    {
        private readonly RentalContext _context;
        public LocalidadRepositorio(RentalContext context)
        {
            _context = context;
        }
        public async Task<List<LocalidadDto>> GetAll()
        {
            var  query = _context.Localidades.Select(x => new LocalidadDto
            {
                Id = x.Id,
                Nombre = x.Nombre
                
            });
            var  result =  query.OrderBy(x => x.Nombre).ToList();
            return result;
        }

        public async Task<List<LocalidadDto>> SearchLocationsByCriteria(SearchCriteria criteria)
        {
            var  query = _context.Localidades.Select(x => new LocalidadDto
            {
                Id = x.Id,
                Nombre = x.Nombre
            });
            if  (criteria.startLocation != 0)
            {
                query = query.Where(x => x.Id == criteria.startLocation);
            }
            if  (criteria.ReturnLocation != 0)
            {
                query = query.Where(x => x.Id == criteria.ReturnLocation);
            }
            criteria.Count = query.Count();            
            var  result = query.OrderBy(x => x.Nombre).ToList();
            return result;
        }
    }
}
