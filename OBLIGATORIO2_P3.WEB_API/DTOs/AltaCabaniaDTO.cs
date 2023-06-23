using Microsoft.AspNetCore.Mvc.Rendering;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace OBLIGATORIO2_P3.WEB_API.DTOs
{
    public class AltaCabaniaDTO
    {

        [Required(ErrorMessage = "Nombre es Requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Descripcion es Requerida")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Debe tener enrtre 10 y 500 caracteres")]
        public string Descripcion { get; set; }
        [Display(Name = "Tiene Jacuzzi?")]
        public bool Jacuzzi { get; set; }
        [Display(Name = "esta Habilitada?")]
        public bool Habilitada { get; set; }
        [Required(ErrorMessage = "Maximo personas Requerido")]
        [Display(Name = "Maxima de Personas")]
        [Range(1, int.MaxValue, ErrorMessage = "minimo 1 persona")]
        public int CantidadMaximaPersonas { get; set; }


        public string? Foto { get; set; }
        [Display(Name = "Tipo de cabaña")]

        [Required]
        public int IdTipo { get; set; }

        
    }
}
