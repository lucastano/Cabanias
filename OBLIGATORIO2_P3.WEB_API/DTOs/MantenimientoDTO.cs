using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace OBLIGATORIO2_P3.WEB_API.DTOs
{
    public class MantenimientoDTO
    {
     
        public DateTime FechaMantenimiento { get; set; }

       
        [Required(ErrorMessage = "Debe ingresar una descripcion del mantenimiento")]
        public string Descripcion { get; set; }

        [Range(0, int.MaxValue)]
        public double CostoMantenimiento { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del trabajador")]
        public string Trabajador { get; set; }

        public int CabaniaCodigo { get; set; }

       
    }
}
