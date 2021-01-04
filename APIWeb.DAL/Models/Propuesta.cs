using System;
using System.Collections.Generic;

namespace APIWeb.DAL.Models
{
    public partial class Propuesta
    {
        public string UsuarioNickUsuario { get; set; }
        public string VehiculoNumeroBastidor { get; set; }
        public string ClienteDni { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }

        public virtual Cliente ClienteDniNavigation { get; set; }
        public virtual Usuario UsuarioNickUsuarioNavigation { get; set; }
        public virtual Vehiculo VehiculoNumeroBastidorNavigation { get; set; }
    }
}
