using APIWeb.BL.Contracts;
using APIWeb.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWeb.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VehiculoController : ControllerBase
    {
        public IVehiculoBL _vehiculoBL { get; set; }

        public VehiculoController(IVehiculoBL vehiculoBL)
        {
            _vehiculoBL = vehiculoBL;
        }

        public ActionResult<IEnumerable<VehiculoDTO>> Get()
        {
            return Ok(_vehiculoBL.Get());
        }
    }
}
