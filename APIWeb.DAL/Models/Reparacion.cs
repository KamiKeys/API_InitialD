using System;
using System.Collections.Generic;

namespace APIWeb.DAL.Models
{
    public partial class Reparacion
    {
        public Reparacion()
        {
            Jornada = new HashSet<Jornada>();
        }

        public string UsuarioNickUsuario { get; set; }
        public string VehiculoNumeroBastidor { get; set; }
        public string IdFactura { get; set; }
        public string Cliente { get; set; }
        public string Piezas { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string TiempoEstimado { get; set; }
        public double PresupuestoEstimado { get; set; }
        public double? Precio { get; set; }
        public DateTime? FechaReparacion { get; set; }

        public virtual Usuario UsuarioNickUsuarioNavigation { get; set; }
        public virtual Vehiculo VehiculoNumeroBastidorNavigation { get; set; }
        public virtual ICollection<Jornada> Jornada { get; set; }
    }
}
