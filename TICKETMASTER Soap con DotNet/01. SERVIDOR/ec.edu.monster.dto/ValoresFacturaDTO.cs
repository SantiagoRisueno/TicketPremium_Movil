using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.SERVIDOR.ec.edu.monster.dto
{
    public class ValoresFacturaDTO
    {
        public double Subtotal { get; set; }

        public double ValorIVA { get; set; }

        public double Total { get; set; }
    }
}