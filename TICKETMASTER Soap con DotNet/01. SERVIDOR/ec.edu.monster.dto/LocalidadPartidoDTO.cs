using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.SERVIDOR.ec.edu.monster.dto
{
    public class LocalidadPartidoDTO
    {
        public int Id { get; set; }
        public int PartidoId { get; set; }
        public int TipoLocalidad { get; set; }
        public string NombreLocalidad { get; set; }
        public double Precio { get; set; }
        public int Disponibilidad { get; set; }
    }
}