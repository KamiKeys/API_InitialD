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
    public class UsuarioController : ControllerBase
    {
        public IUsuarioBL _usuarioBL { get; set; }

        public UsuarioController(IUsuarioBL usuarioBL)
        {
            _usuarioBL = usuarioBL;
        }
        
        [HttpPost]
        public ActionResult<bool> Add(UsuarioDTO usuarioDTO)
        {
            _usuarioBL.Add(usuarioDTO);
            return Ok(true);
        }

        public ActionResult<IEnumerable<UsuarioDTO>> Get()
        {
            return Ok(_usuarioBL.Get());
        }
    }
}
