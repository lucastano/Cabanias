using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace OBLIGATORIO2_P3.WEB_API.DTOs
{
    public class ListarCabaniasDTO
    {
        public string Nombre { get; set; }

        [StringLength(500, MinimumLength = 10, ErrorMessage = "debe tener entre 10 y 500 caracteres")]
        public string Descripcion { get; set; }
        public bool? Jacuzzi { get; set; }
        public bool? Habilitada { get; set; }

        [Key]

        public int NumeroHabitacion { get; set; }
        public int CantidadMaximaPersonas { get; set; }
        public string? Foto { get; set; }
        // secuenciador en un futuro va a aumnetar a medidad de que se suban fotos 
        
        public string TipoCabania { get; set; }
        public List<MantenimientoDTO>? Mantenimientos { get; set; }
        public double CostoPorHuesped { get; set; }
    }
}
