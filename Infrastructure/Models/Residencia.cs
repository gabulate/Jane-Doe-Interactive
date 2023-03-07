
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

    [MetadataType(typeof(ResidenciaMetadata))]
    public partial class Residencia
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Residencia()
    {

        this.Deuda = new HashSet<Deuda>();

    }


    public int Id { get; set; }

    public int Propietario { get; set; }

    public byte Habitantes { get; set; }

    public Nullable<System.DateTime> AnioConstrucion { get; set; }

    public int Condicion { get; set; }

    public byte Vehiculos { get; set; }

    public Nullable<bool> Borrado { get; set; }



    public virtual CondicionResidencia CondicionResidencia { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Deuda> Deuda { get; set; }

    public virtual Usuario Usuario { get; set; }

}

}
