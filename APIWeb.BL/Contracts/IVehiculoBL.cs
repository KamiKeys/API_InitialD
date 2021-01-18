using APIWeb.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIWeb.BL.Contracts
{
    public interface IVehiculoBL
    {
        IEnumerable<VehiculoDTO> Get();
    }
}
