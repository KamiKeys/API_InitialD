using System;
using System.Collections.Generic;

namespace APIWeb.DAL.Models
{
    public partial class Concesionario
    {
        public Concesionario()
        {
            Usuario = new HashSet<Usuario>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public string Direccion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
