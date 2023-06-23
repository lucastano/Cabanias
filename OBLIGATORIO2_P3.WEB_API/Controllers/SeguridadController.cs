using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBLIGATORIO1_P3.APLICACION.InterfacesCasoUso;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects;
using OBLIGATORIO2_P3.WEB_API.DTOs;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;

namespace OBLIGATORIO2_P3.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
       
        private readonly IConfiguration configuration;
        private readonly IObtenerUsuario UcObtenerUsuario;
        private readonly IAgregarUsuario UcagregarUsuario;
        private readonly IValidarPassword UcValidarPassword;

        public SeguridadController(IConfiguration configuration, IObtenerUsuario UcObtenerUsuario,IAgregarUsuario UcAgregarUsuario, IValidarPassword UcValidarPassword)
        {
            this.configuration = configuration;
            this.UcObtenerUsuario = UcObtenerUsuario;
            this.UcagregarUsuario = UcAgregarUsuario;
            this.UcValidarPassword = UcValidarPassword;
        }

        /// <summary>
        /// Registro de usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="UsuarioException"></exception>
        [HttpPost]
        public IActionResult AltaUsuario( UsuarioDTO dto)
        {
            if (!ModelState.IsValid) {

                return BadRequest("LA INFORMACION DEL USUARIO NO ES VALIDA");
            }

            
            try
            {
                Seguridad.CrearPasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                if (!UcValidarPassword.Ejecutar(dto.Password)) throw new UsuarioException("Password invalida");
                UcagregarUsuario.Ejecutar(new Usuario()
                {
                    Mail = MailVO.Crear(dto.Email),
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                    

                });

                return Ok("Usuario registrado correctamente");
                

            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);

            }

        }

        /// <summary>
        /// Login de usuario ya existente 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("La informacion de usuario no es valida.");
                //dto incompleto
            }
            try
            {
                var usuarioDominio = UcObtenerUsuario.Ejecutar(dto.Email);
                //obtiene el usuario con el email proporcionado
                if(usuarioDominio == null) 
                {
                    //si usuario es null, no se encontro usuario con ese email, retorna badrequest
                    return BadRequest("usuario no es valid o no existe");
                }
                //si se encontro el usuario ingresado
                if (!Seguridad.VerificarPasswordHash(dto.Password, usuarioDominio.PasswordHash, usuarioDominio.PasswordSalt))
                {
                    return BadRequest("Las credenciales no son validas.");
                }
                var token=Seguridad.CrearToken(usuarioDominio, configuration);


                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




    }
}
