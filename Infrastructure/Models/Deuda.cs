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
    using System.Collections.Generic;
    
    public partial class Deuda
    {
        public int IdResidencia { get; set; }
        public int IdPlanCobro { get; set; }
        public System.DateTime Fecha { get; set; }
        public bool PendientePago { get; set; }
        public decimal MontoPagado { get; set; }
        public bool Borrado { get; set; }
    
        public virtual PlanCobro PlanCobro { get; set; }
        public virtual Residencia Residencia { get; set; }
    }
}
