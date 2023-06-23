using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBLIGATORIO1_P3.APLICACION.InterfacesCasoUso;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects;
using OBLIGATORIO2_P3.WEB_API.DTOs;

namespace OBLIGATORIO2_P3.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //atributo para utilizar el token
    
    public class TiposController : ControllerBase
    {
        IObtenerTodosTipos UcObtenerTodosTipos;
        IEditarTipo UcEditarTipo;
        IEliminarTipo UcEliminarTipo;
        IAltaTipo UcAltaTipo;
        // IObtenerTipo UcObtenerTipo;
        ITipoPorNombre UcTipoPorNombre;

        public TiposController(IObtenerTodosTipos ucObtenerTodosTipos, ITipoPorNombre UcTipoPorNombre, IEliminarTipo UcEliminarTipo, IAltaTipo UcAltaTipo, IEditarTipo UcEditarTipo)
        {
            this.UcObtenerTodosTipos = ucObtenerTodosTipos;
            this.UcEditarTipo = UcEditarTipo;
            this.UcEliminarTipo = UcEliminarTipo;
            this.UcAltaTipo= UcAltaTipo;
            
            this.UcTipoPorNombre = UcTipoPorNombre;
        }

        /// <summary>
        /// Da de alta un nuevo tipo de cabania
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        [HttpPost]

        public IActionResult AltaTipo(AltaTipoDTO dto) 
        {
           
            if (!ModelState.IsValid) throw new Exception("falto algun dato");

            

            try 
            {
                
                Tipo nuevo = new Tipo
                 {
                Nombre =NombreTipoVO.Crear(dto.Nombre),
                Descripcion = dto.Descripcion,
                CostoPorHuesped = dto.CostoPorHuesped,
                 };

                UcAltaTipo.Ejecutar(nuevo);
                return Ok();
                
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);

            }
        
        
        }

        /// <summary>
        /// Obtiene todos los tipos de cabania 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IEnumerable<Tipo> ObtenerTipos() 
        {
            return UcObtenerTodosTipos.Ejecutar();
            
        }

        /// <summary>
        /// Obtiene un tipo de cabania filtrado por nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>

        [HttpGet("{nombre}")]
        public Tipo ObtenerTiposPorNombre(string nombre)
        {


            return UcTipoPorNombre.Ejecutar(nombre);

        }

        /// <summary>
        /// Elimina un tipo de cabania, el cual se busca por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]

        public IActionResult EliminarTipo(int id) {

            try
            {
                UcEliminarTipo.Ejecutar(id);
                //en caso de eliminar retorna 200
                return Ok();

            }
            catch (Exception ex) 
            {
                // en caso de no poder eliminar retorna 500
                return StatusCode(500,ex.Message);
            
            
            }
            

        }

        /// <summary>
        /// Edita un tipo de cabania 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        [HttpPut]
        public IActionResult Editar(EditarTipoDTO dto)
        {
            if (!ModelState.IsValid) throw new Exception("falta ingresar algun dato");
            Tipo aeditar = new Tipo
            {
                Id = dto.Id,
                Nombre = NombreTipoVO.Crear(dto.Nombre),
                Descripcion = dto.Descripcion,
                CostoPorHuesped = dto.CostoPorHuesped,
            };
            try
            {
                UcEditarTipo.Ejecutar(aeditar);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);

            }
        }

   
       
    }
}
