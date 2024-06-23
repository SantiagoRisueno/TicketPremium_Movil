using _01.SERVIDOR.ec.edu.monster.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.SERVIDOR.ec.edu.monster.dto
{
    public class DatosFacturaFinalDTO
    {
        public string FacturaID { get; set; }
        public string FechaFactura { get; set; }
        public string NombresCliente { get; set; }
        public string ApellidosCliente { get; set; }
        public string EmailCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public double Subtotal { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }
        public List<DetalleFacturaDTO> Detalles { get; set; }
    }
}