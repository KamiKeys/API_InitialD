using Microsoft.AspNetCore.Mvc;
using APIWeb.Core.DTO;
using APIWeb.BL.Contracts;

namespace APIWeb.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoginController
    {

        public IUsuarioBL _usuarioBL { get; set; }

        public LoginController(IUsuarioBL usuarioBL)
        {
            _usuarioBL = usuarioBL;
        }

        [HttpPost]
        public bool Login(UsuarioDTO usuarioDTO)
        {
            return _usuarioBL.Login(usuarioDTO);
        }
    }
}
