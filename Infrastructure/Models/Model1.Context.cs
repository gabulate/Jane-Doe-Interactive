//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CondominiosDBEntities : DbContext
    {
        public CondominiosDBEntities()
            : base("name=CondominiosDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AreaComun> AreaComun { get; set; }
        public virtual DbSet<CondicionResidencia> CondicionResidencia { get; set; }
        public virtual DbSet<Deuda> Deuda { get; set; }
        public virtual DbSet<EstadoIncidente> EstadoIncidente { get; set; }
        public virtual DbSet<Incidente> Incidente { get; set; }
        public virtual DbSet<Informacion> Informacion { get; set; }
        public virtual DbSet<PlanCobro> PlanCobro { get; set; }
        public virtual DbSet<Reservacion> Reservacion { get; set; }
        public virtual DbSet<Residencia> Residencia { get; set; }
        public virtual DbSet<RubroCobro> RubroCobro { get; set; }
        public virtual DbSet<TipoInformacion> TipoInformacion { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
