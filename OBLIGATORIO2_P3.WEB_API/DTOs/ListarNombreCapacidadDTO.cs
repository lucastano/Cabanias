using System.ComponentModel.DataAnnotations;

namespace OBLIGATORIO2_P3.WEB_API.DTOs
{
    public class ListarNombreCapacidadDTO
    {

        [Required]
       public string Nombre { get; set; }
        [Required]
       public int CantidadMaximaPersonas { get; set; }

    }
}
