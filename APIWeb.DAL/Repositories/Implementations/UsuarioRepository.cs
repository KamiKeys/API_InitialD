using APIWeb.Core.DTO;
using APIWeb.Core.Utils;
using APIWeb.DAL.Models;
using APIWeb.DAL.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace APIWeb.DAL.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {

        public InitialDContext _context { get; set; }

        public UsuarioRepository(InitialDContext context)
        {
            _context = context;
        }

        public bool Login(UsuarioDTO usuarioDTO)
        {
            return _context.Usuario.Any(u => u.NickUsuario == usuarioDTO.Username && u.Contrasenia == Security.GetMD5(usuarioDTO.Password));
        }

        public void Add(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                NickUsuario = usuarioDTO.Username,
                Contrasenia = Security.GetMD5(usuarioDTO.Password),
                Dni = usuarioDTO.Dni,
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                JefeMecanico = usuarioDTO.JefeMecanico,
                Especialidad = usuarioDTO.Especialidad,
                Email = usuarioDTO.Email,
                Tlf = usuarioDTO.Tlf,
                Imagen = usuarioDTO.Imagen,
                RolIdRol = usuarioDTO.RolIdRol,
                ConcesionarioDireccion = usuarioDTO.ConcesionarioDireccion,

            };

            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<UsuarioDTO> Get()
        {
            var usuarios = _context.Usuario.ToList();
            
            //Mapeo de Usuario a UsuarioDTO
            List<UsuarioDTO> usuariosdto = new List<UsuarioDTO>();

            foreach(var u in usuarios)
            {
                var usuario = new UsuarioDTO
                {
                    Username = u.NickUsuario,
                    Password = Security.GetMD5(u.Contrasenia),
                    Dni = u.Dni,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    JefeMecanico = u.JefeMecanico,
                    Especialidad = u.Especialidad,
                    Email = u.Email,
                    Tlf = u.Tlf,
                    Imagen = u.Imagen,
                    RolIdRol = u.RolIdRol,
                    ConcesionarioDireccion = u.ConcesionarioDireccion,

                };

                usuariosdto.Add(usuario);
            }

            return usuariosdto;
        }
    }
}
