
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Infrastructure.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(DeudaMetadata))]
    public partial class Deuda
{

    public int IdResidencia { get; set; }

    public int IdPlanCobro { get; set; }

    public System.DateTime Fecha { get; set; }

    public bool PendientePago { get; set; }

    public decimal MontoPagado { get; set; }

    public bool Borrado { get; set; }

    public int Id { get; set; }



    public virtual PlanCobro PlanCobro { get; set; }

    public virtual Residencia Residencia { get; set; }

}

}
