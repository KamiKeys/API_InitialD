using APIWeb.Core.DTO;
using APIWeb.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using APIWeb.DAL.Repositories.Contracts;

namespace APIWeb.DAL.Repositories.Implementations
{
    public class VehiculoRepository : IVehiculoRepository
    {
        public InitialDContext _context { get; set; }

        public VehiculoRepository(InitialDContext context)
        {
            _context = context;
        }

        public IEnumerable<VehiculoDTO> Get()
        {
            var vehiculos = _context.Vehiculo.ToList();

            //Mapeo de Vehiculo a VehiculoDTO
            List<VehiculoDTO> vehiculosdto = new List<VehiculoDTO>();

            foreach (var v in vehiculos)
            {
                var vehiculo = new VehiculoDTO
                {
                    Matricula = v.Matricula,
                    Marca = v.Marca,
                    Modelo = v.Modelo,
                    Precio = v.Precio,
                    ConcesionarioDireccion = v.ConcesionarioDireccion,
                    UsuarioNickUsuario = v.UsuarioNickUsuario,
                    FechaVenta = v.FechaVenta,

                };
                if (vehiculo.FechaVenta != null) //Solo para vehículos vendidos
                    vehiculosdto.Add(vehiculo);
            }

            return vehiculosdto;
        }
    }
}
