using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.SERVIDOR.ec.edu.monster.dto
{
    public class PartidoFutbolDTO
    {
        public int Id { get; set; } 
        public int EstadioId { get; set; }
        public string NombreEstadio { get; set; } 
        public string EquipoLocal { get; set; }
        public string EquipoVisita { get; set; } 
        public string LogoEquipoLocal { get; set; }
        public string LogoEquipoVisita { get; set; } 
        public DateTime Fecha { get; set; } 
        public DateTime Hora { get; set; } 
    }
}