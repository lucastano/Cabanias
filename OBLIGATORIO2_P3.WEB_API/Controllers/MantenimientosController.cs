using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OBLIGATORIO1_P3.APLICACION.CasosUso;
using OBLIGATORIO1_P3.APLICACION.InterfacesCasoUso;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects;
using OBLIGATORIO2_P3.WEB_API.DTOs;
using System.Globalization;

namespace OBLIGATORIO2_P3.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MantenimientosController:ControllerBase
    {
        private readonly IAltaMantenimiento ucAltaMantenimiento;
        private readonly IObtenerListaMantenimientos ucObtenerListaMantenimientos;
        private readonly IObtenerListaMantenimientosCabaniaEntreFechas ucObtenerListaMantenimientosCabaniaEntreFechas;
        private readonly IObtenerCabaniaPorNumeroHabitacion ucobtenerCabaniaPorNumeroHabitacion;
        private readonly IObtenerListaMantenimientosCabania UcObtenerMantenimientosDeCabania;
        public MantenimientosController(IAltaMantenimiento ucAltaMantenimiento, IObtenerListaMantenimientos ucObtenerListaMantenimientos, IObtenerListaMantenimientosCabaniaEntreFechas ucObtenerListaMantenimientosCabaniaEntreFechas, IObtenerCabaniaPorNumeroHabitacion ucobtenerCabaniaPorNumeroHabitacion, IObtenerListaMantenimientosCabania UcObtenerMantenimientosDeCabania)
        {
            this.ucAltaMantenimiento=ucAltaMantenimiento;
            this.ucObtenerListaMantenimientos = ucObtenerListaMantenimientos;
            this.ucObtenerListaMantenimientosCabaniaEntreFechas = ucObtenerListaMantenimientosCabaniaEntreFechas;
            this.ucobtenerCabaniaPorNumeroHabitacion = ucobtenerCabaniaPorNumeroHabitacion;
            this.UcObtenerMantenimientosDeCabania = UcObtenerMantenimientosDeCabania;
        }

        /// <summary>
        /// Metodo/Funcion que obtiene todo el listado entero de mantenimientos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<MantenimientoDTO> ListarMantenimintos()
        {
            var mantenimientos = ucObtenerListaMantenimientos.Ejecutar();
            return mantenimientos.Select(x => new MantenimientoDTO()
            {
                FechaMantenimiento = x.FechaMantenimiento,
                Descripcion = x.Descripcion.Valor,
                CostoMantenimiento = x.CostoMantenimiento,
                Trabajador = x.Trabajador,    
                CabaniaCodigo=x.cabaniaCodigo

            });

        }
        /// <summary>
        /// Metodo/Funcion que da de alta un mantenimiento
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Alta(AltaMantenimientoDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                Mantenimiento mantenimiento = new Mantenimiento()
                {
                    FechaMantenimiento = model.FechaMantenimiento,
                    Descripcion =DescripcionMantenimientoVO.Crear(model.Descripcion),
                    CostoMantenimiento = model.CostoMantenimiento,
                    Trabajador = model.Trabajador,  
                    //REvisar linea de abajo
                    Cabania = ucobtenerCabaniaPorNumeroHabitacion.Ejecutar(model.cabaniaCodigo),
                    cabaniaCodigo =model.cabaniaCodigo
                };
                ucAltaMantenimiento.Ejecutar(mantenimiento);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        /// <summary>
        /// Metodo/Funcion que obtiene todo el listado de mantenimientos entre fechas
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <returns></returns>

        [HttpGet("entre-fechas")]
        public IEnumerable<MantenimientoDTO> ObtenerMantenimientoPorFecha(int id,DateTime fechaDesde, DateTime fechaHasta)
        {
            

            var mantenimientos = ucObtenerListaMantenimientosCabaniaEntreFechas.Ejecutar(id, fechaDesde, fechaHasta);

            return mantenimientos.Select(x => new MantenimientoDTO()
            {
                FechaMantenimiento = x.FechaMantenimiento,
                Descripcion = x.Descripcion.Valor,
                CostoMantenimiento = x.CostoMantenimiento,
                Trabajador = x.Trabajador,
                CabaniaCodigo = x.cabaniaCodigo

            });
        }

        /// <summary>
        /// Obtiene los mantenimientos de la cabania indicada por id de cabania
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="CabaniaException"></exception>

        [HttpGet("por-cabania")]
        public IEnumerable<MantenimientoDTO> ObtenerMantenimientosDeCabania(int Id)
        {
            if (Id == 0) throw new CabaniaException("No existe una cabania con ese ID");
            var mantenimientos = UcObtenerMantenimientosDeCabania.Ejecutar(Id);

            return mantenimientos.Select(x => new MantenimientoDTO()
            {
                FechaMantenimiento = x.FechaMantenimiento,
                Descripcion = x.Descripcion.Valor,
                Trabajador = x.Trabajador,
                CostoMantenimiento = x.CostoMantenimiento,
                
                
                
            });
        }
    }
}
