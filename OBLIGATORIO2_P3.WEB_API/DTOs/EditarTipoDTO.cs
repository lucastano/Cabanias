using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace OBLIGATORIO2_P3.WEB_API.DTOs
{
    public class EditarTipoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public double CostoPorHuesped { get; set; }
    }
}
