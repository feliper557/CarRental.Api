using CarRental.Api.Aplication.Services;
using CarRental.Api.Dominio.Entities;
using CarRental.Api.Model;
using CarRental.Api.Presentacion.Dtos;
using System.Data.Entity;


namespace CarRental.Api.Dominio.Repository
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly RentalContext _context;
        public VehiculoRepository(RentalContext context)
        {
            _context = context;          
            
        }
        public async Task<List<VehiculoDTO>> GetAll(SearchCriteria searchCriteria)
        {
            //var query = _context.Vehiculos.Select(x => new VehiculoDTO
            //{
            //    Id = x.Id,
            //    Capacidad = x.Capacidad,
            //    Marca = x.Marca,
            //    Modelo = x.Modelo,
            //    Disponible = x.Disponible,
            //    Localidad = new LocalidadDto
            //    {
            //        Nombre = x.Localidad.Nombre,
            //        Id = x.Localidad.Id
            //    },
            //    Mercado = new MercadoDto
            //    {
            //        Id = x.Mercado.Id,
            //        Nombre = x.Mercado.Nombre
            //    }
                
            //});
            //searchCriteria.Count = query.Count();
            //var result =  query.OrderBy(x => x.Id).ToList();
            //return result;
            var  query  = _context.Vehiculos.
                Join(_context.Localidades, v => v.LocalidadId, l => l.Id, (v, l) => new { v, l }).
                Join(_context.Mercados, vl => vl.v.MercadoId, m => m.Id, (vl, m) => new { vl, m }).
                Select(x => new VehiculoDTO
                {
                    Id = x.vl.v.Id,
                    Capacidad = x.vl.v.Capacidad,
                    Marca = x.vl.v.Marca,
                    Modelo = x.vl.v.Modelo,
                    Localidad = new LocalidadDto
                    {
                        Nombre = x.vl.l.Nombre,
                        Id = x.vl.l.Id
                    },
                    Mercado = new MercadoDto
                    {
                        Id = x.m.Id,
                        Nombre = x.m.Nombre
                    }
                });
            searchCriteria.Count = query.Count();
            var result =  query.OrderBy(x => x.Id)
                //.Skip(searchCriteria.PageSize * (searchCriteria.Page))
                //.Take(searchCriteria.PageSize)
                .ToList();
            return result;
               
        }
        public async Task<List<VehiculoDTO>> SearchVehiclesbyLocation(SearchCriteria searchCriteria)
        {
            var query = _context.Vehiculos
                .Select(x => new VehiculoDTO
                {
                    Id = x.Id,
                    Capacidad = x.Capacidad,
                    Marca = x.Marca,
                    Modelo = x.Modelo,                    
                    Localidad = new LocalidadDto
                    {
                        Nombre = x.Localidad.Nombre,
                        Id = x.Localidad.Id
                    },
                    Mercado = new MercadoDto
                    {
                        Id = x.Mercado.Id,
                        Nombre = x.Mercado.Nombre
                    }
                });

            if (searchCriteria.startLocation != 0)
            {
                query = query.Where(x => x.LocalidadId == searchCriteria.startLocation);
            }
            if (searchCriteria.VehicleType is not null)
            {
                query = query.Where(x => x.Modelo == searchCriteria.VehicleType);
            }

            searchCriteria.Count = query.Count();
            var result = query.OrderBy(x => x.Id)
                //.Skip(searchCriteria.PageSize * (searchCriteria.Page))
                //.Take(searchCriteria.PageSize)
                .ToList();
            return result;
        }

        public async Task<List<VehiculoDTO>> SearchVehiclesbyMarket(SearchCriteria searchCriteria)
        {
            var query = _context.Vehiculos
                 .Select(x => new VehiculoDTO
                 {
                     Id = x.Id,
                     Capacidad = x.Capacidad,
                     Marca = x.Marca,
                     Modelo = x.Modelo,                     
                     Localidad = new LocalidadDto
                     {
                         Nombre = x.Localidad.Nombre,
                         Id = x.Localidad.Id
                     },
                     Mercado = new MercadoDto
                     {
                            Id = x.Mercado.Id,
                            Nombre = x.Mercado.Nombre
                        }
                 });
            if (searchCriteria.IdMercado != 0)
            {
                query = query.Where(x => x.MercadoId == searchCriteria.IdMercado);
            }
            if (searchCriteria.VehicleType is not null)
            {
                query = query.Where(x => x.Modelo == searchCriteria.VehicleType);
            }
            searchCriteria.Count = query.Count();
            var result =  query.OrderBy(x => x.Id)
                //.Skip(searchCriteria.PageSize * (searchCriteria.Page))
                //.Take(searchCriteria.PageSize)
                .ToList();
            return result;
        }

        public VehiculoDTO Buscarautopor()
        {
            var query = _context.Vehiculos
              .Select(x => new VehiculoDTO
              {
                  Id = x.Id,
                  Capacidad = x.Capacidad,
                  Marca = x.Marca,
                  Modelo = x.Modelo,
                  Localidad = _context.Localidades.Where(y => y.Id == x.LocalidadId).Select(y => new LocalidadDto
                  {
                      Nombre = y.Nombre,
                      Id = y.Id

                  }).FirstOrDefault(),
                  Mercado = _context.Mercados.Where(z => z.Id == x.MercadoId).Select(z => new MercadoDto
                  {
                      Id = z.Id,
                      Nombre = z.Nombre

                  }).FirstOrDefault()
              }).FirstOrDefault();
            return query;
        }
    }
}
