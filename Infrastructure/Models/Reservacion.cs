
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
    
public partial class Reservacion
{

    public int Id { get; set; }

    public int IdAreaComun { get; set; }

    public int IdUsuario { get; set; }

    public System.TimeSpan HoraInicio { get; set; }

    public System.TimeSpan HoraFinal { get; set; }

    public bool Borrado { get; set; }



    public virtual AreaComun AreaComun { get; set; }

    public virtual Usuario Usuario { get; set; }

}

}
