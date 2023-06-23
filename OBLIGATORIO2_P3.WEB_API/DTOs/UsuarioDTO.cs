using System.ComponentModel.DataAnnotations;

namespace OBLIGATORIO2_P3.WEB_API.DTOs
{
    public class UsuarioDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
