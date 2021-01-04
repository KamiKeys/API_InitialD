using System;
using System.Collections.Generic;

namespace APIWeb.DAL.Models
{
    public partial class Jornada
    {
        public string Reparacion { get; set; }
        public string UsuarioNickUsuario { get; set; }

        public virtual Reparacion ReparacionNavigation { get; set; }
        public virtual Usuario UsuarioNickUsuarioNavigation { get; set; }
    }
}
