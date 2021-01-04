using System;
using System.Collections.Generic;
using System.Text;

namespace APIWeb.Core.DTO
{
    public class UsuarioDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string JefeMecanico { get; set; }
        public string Especialidad { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public byte[] Imagen { get; set; }
        public int RolIdRol { get; set; }
        public string ConcesionarioDireccion { get; set; }

        public UsuarioDTO()
        {

        }
    }
}
