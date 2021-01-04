using System;
using System.Collections.Generic;

namespace APIWeb.DAL.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Propuesta = new HashSet<Propuesta>();
            Reparacion = new HashSet<Reparacion>();
        }

        public string NumeroBastidor { get; set; }
        public string Matricula { get; set; }
        public byte[] Imagen { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double? Precio { get; set; }
        public DateTime FechaEntrada { get; set; }
        public bool PropiedadConcesionario { get; set; }
        public string ConcesionarioDireccion { get; set; }
        public int TipoIdTipo { get; set; }
        public string ClienteDni { get; set; }
        public string UsuarioNickUsuario { get; set; }
        public DateTime? FechaVenta { get; set; }
        public int Anno { get; set; }
        public int Kms { get; set; }
        public string Combustible { get; set; }

        public virtual Cliente ClienteDniNavigation { get; set; }
        public virtual Concesionario ConcesionarioDireccionNavigation { get; set; }
        public virtual Tipo TipoIdTipoNavigation { get; set; }
        public virtual Usuario UsuarioNickUsuarioNavigation { get; set; }
        public virtual ICollection<Propuesta> Propuesta { get; set; }
        public virtual ICollection<Reparacion> Reparacion { get; set; }
    }
}
