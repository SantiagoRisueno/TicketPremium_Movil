//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _01.SERVIDOR.ec.edu.monster.modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class detalle_factura
    {
        public int DETF_ID { get; set; }
        public int LOC_ID { get; set; }
        public string FAC_CODIGO { get; set; }
        public int DETF_CANTIDAD { get; set; }
        public decimal DETF_TOTAL { get; set; }
    
        public virtual localidad_partido localidad_partido { get; set; }
        public virtual factura factura { get; set; }
    }
}
