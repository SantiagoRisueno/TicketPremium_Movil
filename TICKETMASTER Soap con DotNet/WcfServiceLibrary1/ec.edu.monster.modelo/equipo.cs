//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceLibrary1.ec.edu.monster.modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class equipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public equipo()
        {
            this.partido_futbol = new HashSet<partido_futbol>();
            this.partido_futbol1 = new HashSet<partido_futbol>();
        }
    
        public int EQU_ID { get; set; }
        public string EQU_NOMBRE { get; set; }
        public string EQUI_IMG { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<partido_futbol> partido_futbol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<partido_futbol> partido_futbol1 { get; set; }
    }
}
