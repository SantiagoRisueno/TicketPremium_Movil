using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.SERVIDOR.ec.edu.monster.dto
{
    public class DetalleFacturaDTO
    {
        public int LocalidadId { get; set; }
        public string NombreLocalidad { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public double Precio { get; set; }
        public string FacturaCodigo { get; set; }
    }
}