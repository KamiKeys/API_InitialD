using System;
using System.Collections.Generic;

namespace APIWeb.DAL.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdTipo { get; set; }
        public string Tipo1 { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
