using System;
using System.Collections.Generic;
using System.Text;

namespace APIWeb.Core.DTO
{
    public class VehiculoDTO
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double? Precio { get; set; }
        public string UsuarioNickUsuario { get; set; }
        public DateTime? FechaVenta { get; set; }

        public VehiculoDTO()
        {

        }
    }
}
