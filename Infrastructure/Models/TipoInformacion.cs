
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
    
public partial class TipoInformacion
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public TipoInformacion()
    {

        this.Informacion = new HashSet<Informacion>();

    }


    public int Id { get; set; }

    public string Descripcion { get; set; }

    public bool Borrado { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Informacion> Informacion { get; set; }

}

}
