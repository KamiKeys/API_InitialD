using System;
using System.Collections.Generic;

namespace APIWeb.DAL.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Propuesta = new HashSet<Propuesta>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }

        public virtual ICollection<Propuesta> Propuesta { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
