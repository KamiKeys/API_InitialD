using System;
using System.Collections.Generic;

namespace APIWeb.DAL.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            InverseJefeMecanicoNavigation = new HashSet<Usuario>();
            Jornada = new HashSet<Jornada>();
            Propuesta = new HashSet<Propuesta>();
            Reparacion = new HashSet<Reparacion>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public string NickUsuario { get; set; }
        public string Contrasenia { get; set; }
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

        public virtual Concesionario ConcesionarioDireccionNavigation { get; set; }
        public virtual Usuario JefeMecanicoNavigation { get; set; }
        public virtual Rol RolIdRolNavigation { get; set; }
        public virtual ICollection<Usuario> InverseJefeMecanicoNavigation { get; set; }
        public virtual ICollection<Jornada> Jornada { get; set; }
        public virtual ICollection<Propuesta> Propuesta { get; set; }
        public virtual ICollection<Reparacion> Reparacion { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
