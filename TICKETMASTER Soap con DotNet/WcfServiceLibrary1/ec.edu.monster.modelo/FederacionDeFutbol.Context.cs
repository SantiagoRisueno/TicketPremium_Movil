﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class federacion_futbolEntities : DbContext
    {
        public federacion_futbolEntities()
            : base("name=federacion_futbolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<detalle_factura> detalle_factura { get; set; }
        public virtual DbSet<equipo> equipo { get; set; }
        public virtual DbSet<estadio> estadio { get; set; }
        public virtual DbSet<factura> factura { get; set; }
        public virtual DbSet<localidad_partido> localidad_partido { get; set; }
        public virtual DbSet<partido_futbol> partido_futbol { get; set; }
        public virtual DbSet<tipo_localidad> tipo_localidad { get; set; }
    }
}
