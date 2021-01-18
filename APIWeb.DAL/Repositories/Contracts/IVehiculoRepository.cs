using APIWeb.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIWeb.DAL.Repositories.Contracts
{
    public interface IVehiculoRepository
    {
        IEnumerable<VehiculoDTO> Get();
    }
}
