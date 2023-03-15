using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.Models
{
    internal partial class ResidenciaMetadata
    {
        [Display(Name = "Código de Residencia")]
        public int Id { get; set; }

        [Display(Name = "Id Propietario")]
        public int Propietario { get; set; }

        public byte Habitantes { get; set; }

        [Display(Name = "Año de Construcción")]
        public Nullable<System.DateTime> AnioConstrucion { get; set; }

        [Display(Name = "Condición")]
        public int Condicion { get; set; }

        [Display(Name = "Cantidad de Vehículos")]
        public byte Vehiculos { get; set; }


        public virtual Usuario Usuario { get; set; }

        [Display(Name = "Historial")]
        public virtual ICollection<Deuda> Deuda { get; set; }
        public Nullable<bool> Borrado { get; set; }
    }
    internal partial class UsuarioMetadata
    {
        public int Id { get; set; }
        public int IdTipoUsuario { get; set; }

        [Display(Name = "Propietario")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public string Email { get; set; }
        public string Contrasenna { get; set; }

        public virtual ICollection<Residencia> Residencia { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }

        public bool Borrado { get; set; }


    }
    internal partial class PlanCobroMetadata
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
       

        [Display(Name = "Monto Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]  //para agregar signo de colones. el 0 reemplaza con el valor que representa. El C representa el signo de de colones
        //[RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$")] EL HIJO DEL DEMONIO!

        public decimal MontoTotal { get; set; }
        public bool Borrado { get; set; }

        [Display(Name = "Rubros de Cobro")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public virtual ICollection<RubroCobro> RubroCobro { get; set; }

    }

    internal partial class CondicionResidenciaMetadata
    {
        public int Id { get; set; }

        [Display(Name = "Condición")]
        public string Descripcion { get; set; }
        public bool Borrado { get; set; }
    }

    internal partial class RubroCobroMetadata 
    {
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Descripcion { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        //[RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "Solo se aceptan números con dos decimales y con punto.")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public decimal Costo { get; set; }
    }

    internal partial class DeudaMetadata
    {
        [Display(Name = "Código de Residencia")]
        public int IdResidencia { get; set; }

        public int IdPlanCobro { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM-yyyy}")]
        public System.DateTime Fecha { get; set; }

        [Display(Name = "Pendiente de pago")]
        public bool PendientePago { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$")]
        [Display(Name = "Monto Pagado")]
        public decimal MontoPagado { get; set; }

        public bool Borrado { get; set; }

        [Display(Name = "Número de factura")]
        public int Id { get; set; }
    }

    internal partial class TipoInformacionMetadata
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de información")]
        public string Descripcion { get; set; }
        public bool Borrado { get; set; }
    }

    internal partial class InformacionMetadata
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Texto { get; set; }

        [Display(Name = "Documento")]
        public byte[] Doc1 { get; set; }

        [Display(Name = "Tipo de información")]
        public int IdTipoInformacion { get; set; }

        public bool Borrado { get; set; }
    }

    internal partial class IncidenteMetadata
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public int Estado { get; set; }

        public bool Borrado { get; set; }

        public virtual EstadoIncidente EstadoIncidente { get; set; }
        public virtual Usuario Usuario { get; set; }
    }

    internal partial class EstadoIncidenteMetadata
    {
        public int Id { get; set; }

        [Display(Name = "Estado")]
        public string Descripcion { get; set; }
        public bool Borrado { get; set; }
    }
}
