using APIWeb.BL.Contracts;
using APIWeb.Core.DTO;
using APIWeb.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIWeb.BL.Implementations
{
    public class VehiculoBL : IVehiculoBL
    {
        public IVehiculoRepository _vehiculoRepository { get; set; }

        public VehiculoBL(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public IEnumerable<VehiculoDTO> Get()
        {
            var vehiculos = _vehiculoRepository.Get();
            return vehiculos;
        }
    }
}
