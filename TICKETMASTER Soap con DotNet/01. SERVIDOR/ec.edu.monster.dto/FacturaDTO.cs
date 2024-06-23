using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.SERVIDOR.ec.edu.monster.dto
{
    public class FacturaDTO
    {
        public string ClienteId { get; set; }       
        public string FechaEmision { get; set; }    
        public double SubTotal { get; set; }      
        public double ValorIVA { get; set; }     
        public double Total { get; set; }
    }
}