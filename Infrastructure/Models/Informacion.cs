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
    
    public partial class Informacion
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public byte[] Doc1 { get; set; }
        public byte[] Doc2 { get; set; }
        public byte[] Doc3 { get; set; }
        public int TipoInformacion { get; set; }
        public bool Borrado { get; set; }
    
        public virtual TipoInformacion TipoInformacion1 { get; set; }
    }
}