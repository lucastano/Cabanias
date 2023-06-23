using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBLIGATORIO1_P3.APLICACION.InterfacesCasoUso;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects;
using OBLIGATORIO2_P3.WEB_API.DTOs;

namespace OBLIGATORIO2_P3.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CabaniasController : ControllerBase
    {
        private readonly IAltaCabania UcAltaCabania;
        private readonly IObtenerCabaniaPorNumeroHabitacion UcObtenerCabaniaPorNumeroHabitacion;
        private readonly IObtenerListaCabaniasTipo UcObtenerCabaniasPorTipo;
        private readonly IObtenerListaCabaniasNombre UcObtenerListaCabaniasPorNombre;
        private readonly IObtenerListaCabaniasMaxPer UcObtenerListaCabaniasPorMaxPersonas;
        private readonly IObtenerListaCabaniasHabilitadas UcObtenerListaCabaniasHabilitadas;
        private readonly IObtenerTodasCabanias UcObtenerTodasLasCabanias;
        private readonly IObtenerTodosTipos UcObtenerTodosLosTipos;
        private readonly IObtenerTipo UcObtenerTipoPorId;
        private readonly IObtenerCabaniaPorTipoYMonto UcCabaniasPorTipoYMonto;
        private readonly IObtenerMantenimientosPorValor UcObtenerMantenimientosPorValor;

        public CabaniasController(IAltaCabania UcAltaCabania, IObtenerCabaniaPorNumeroHabitacion UcObtenerCabaniaPorNumeroHabitacion, IObtenerListaCabaniasTipo UcObtenerCabaniasPorTipo,
           IObtenerListaCabaniasNombre UcObtenerListaCabaniasPorNombre, IObtenerListaCabaniasMaxPer UcObtenerListaCabaniasPorMaxPersonas, IObtenerListaCabaniasHabilitadas UcObtenerListaCabaniasHabilitadas,
           IObtenerTodasCabanias UcObtenerTodasLasCabanias, IObtenerTodosTipos UcObtenerTodosLosTipos, IObtenerTipo UcObtenerTipoPorId, IObtenerCabaniaPorTipoYMonto UcCabaniasPorTipoYMonto, IObtenerMantenimientosPorValor UcObtenerMantenimientosPorValor)
        {
            this.UcAltaCabania = UcAltaCabania;
            this.UcObtenerCabaniaPorNumeroHabitacion = UcObtenerCabaniaPorNumeroHabitacion;
            this.UcObtenerCabaniasPorTipo = UcObtenerCabaniasPorTipo;
            this.UcObtenerListaCabaniasPorNombre = UcObtenerListaCabaniasPorNombre;
            this.UcObtenerListaCabaniasPorMaxPersonas = UcObtenerListaCabaniasPorMaxPersonas;
            this.UcObtenerListaCabaniasHabilitadas = UcObtenerListaCabaniasHabilitadas;
            this.UcObtenerTodasLasCabanias = UcObtenerTodasLasCabanias;
            this.UcObtenerTodosLosTipos = UcObtenerTodosLosTipos;
            this.UcObtenerTipoPorId = UcObtenerTipoPorId;
            this.UcCabaniasPorTipoYMonto = UcCabaniasPorTipoYMonto;
            this.UcObtenerMantenimientosPorValor = UcObtenerMantenimientosPorValor;
        }

        /// <summary>
        ///obtiene los mantenimientos a cabanias con capacidad comprendida por los parametros dados, agrupa por nombre de trabajador y   Retorna nombre de trabajador y monto total de los mantenimientos que realizo , 
        /// </summary>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <returns></returns>
        /// <exception cref="CabaniaException"></exception>

        [HttpGet("ListarMantenimientosSegunCapacidad")]
        public IEnumerable<MantenimientosPorCapacidadDTO> ListarMantenimientosSegunCapacidadMaxima(int desde,int hasta) 
        {
            if (desde < 0) throw new CabaniaException("No debe ser negativo");
            if (hasta <= 0) throw new CabaniaException("No debe ser negativo y superior a 0 ");

           var mantenimientos = UcObtenerMantenimientosPorValor.Ejecutar(desde, hasta);
            return mantenimientos.Select(c => new MantenimientosPorCapacidadDTO()
            {
                NombreTrabajador = c.NombreTrabajador,
                TotalMantenimientos = c.TotalMantenimientos,
            });

        }
        /// <summary>
        /// Retorna  retorna lista de nombre y capacidad de las cabanias con el id dado  con consto menor al costo dado, que tengan jacuzzi y esten habilitadas
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="costo"></param>
        /// <returns></returns>

        [HttpGet("ListarCabaniasPorCapacidadYMonto")]
        public IEnumerable<ListarNombreCapacidadDTO> ListarCabaniasPorCapacidadYMonto(int tipo,int costo)
        {
           var cabanias = UcCabaniasPorTipoYMonto.Ejecutar(tipo,costo);
            var tipoBuscado = UcObtenerTipoPorId.Ejecutar(tipo);
               
                if (tipoBuscado == null) throw new TipoException("No existe tipo con ese id");
                 return cabanias.Select(x => new ListarNombreCapacidadDTO()
                  {
                     Nombre = x.Nombre.Valor,
                     CantidadMaximaPersonas = x.CantidadMaximaPersonas

                 
                  });


        }
        /// <summary>
        /// Retorna el listado de todas las cabanias
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IEnumerable<ListarCabaniasDTO> ListarCabanias()
        {
            var cabanias = UcObtenerTodasLasCabanias.Ejecutar();

            return cabanias.Select(x => new ListarCabaniasDTO()
            {
                NumeroHabitacion = x.NumeroHabitacion,
                CantidadMaximaPersonas = x.CantidadMaximaPersonas,
                Nombre = x.Nombre.Valor,
                TipoCabania = x.TipoCabana.Nombre.Valor,
                CostoPorHuesped=x.TipoCabana.CostoPorHuesped,
                Descripcion=x.Descripcion,
                Jacuzzi=x.Jacuzzi,
                Habilitada=x.Habilitada,
                Foto=x.Foto,
                Mantenimientos = x.Mantenimientos.Select(x => new MantenimientoDTO()
                  {
                    CostoMantenimiento = x.CostoMantenimiento,
                    FechaMantenimiento = x.FechaMantenimiento,
                    Descripcion = x.Descripcion.Valor,
                    Trabajador = x.Trabajador

                  }).ToList()

            }) ; 


        }
        
        /// <summary>
        ///     Retorna la lista de Cabanias habilitadas
        /// </summary>
        /// <returns>IEnumerable ListarCabaniasDTO </returns>
        [HttpGet("Habilitadas")]
        public IEnumerable<ListarCabaniasDTO> ObtenerHabilitadas()
        {
            var cabanias = UcObtenerListaCabaniasHabilitadas.Ejecutar();
            return cabanias.Select(x => new ListarCabaniasDTO()
            {
                NumeroHabitacion = x.NumeroHabitacion,
                CantidadMaximaPersonas = x.CantidadMaximaPersonas,
                Nombre = x.Nombre.Valor,
                TipoCabania = x.TipoCabana.Nombre.Valor,
                CostoPorHuesped=x.TipoCabana.CostoPorHuesped,
                Descripcion = x.Descripcion,
                Jacuzzi = x.Jacuzzi,
                Habilitada = x.Habilitada,
                Foto = x.Foto,
                Mantenimientos = x.Mantenimientos.Select(x => new MantenimientoDTO()
                {
                    CostoMantenimiento = x.CostoMantenimiento,
                    FechaMantenimiento = x.FechaMantenimiento,
                    Descripcion = x.Descripcion.Valor,
                    Trabajador = x.Trabajador

                }).ToList()

            });
        }

        /// <summary>
        /// Metodo/Funciòn que Obtiene el Listado de cabañas por nombre de cabaña
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Lista de cabanias filtradas por nombre</returns>
        [HttpGet("{nombre}")]
        public IEnumerable<ListarCabaniasDTO> ObtenerPorNombre(string nombre)
        {

            var cabanias = UcObtenerListaCabaniasPorNombre.Ejecutar(nombre);
            return cabanias.Select(x => new ListarCabaniasDTO()
            {
                NumeroHabitacion = x.NumeroHabitacion,
                CantidadMaximaPersonas = x.CantidadMaximaPersonas,
                Nombre = x.Nombre.Valor,
                TipoCabania = x.TipoCabana.Nombre.Valor,
                CostoPorHuesped=x.TipoCabana.CostoPorHuesped,
                Descripcion = x.Descripcion,
                Jacuzzi = x.Jacuzzi,
                Habilitada = x.Habilitada,
                Foto = x.Foto,
                Mantenimientos = x.Mantenimientos.Select(x => new MantenimientoDTO()
                {
                    CostoMantenimiento = x.CostoMantenimiento,
                    FechaMantenimiento = x.FechaMantenimiento,
                    Descripcion = x.Descripcion.Valor,
                    Trabajador = x.Trabajador

                }).ToList()

            });
        }

        /// <summary>
        /// Metodo/Funcion que Obtiene el Listado de cabañas por tipo de Cabaña (IdCabaña)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista Cabaña</returns>
       
  
         [HttpGet("por-Tipo/{id}")]
        public IEnumerable<ListarCabaniasDTO> ObtenerCabaniasPorTipo(int id)
        {

            var cabanias = UcObtenerCabaniasPorTipo.Ejecutar(id);

            return cabanias.Select(x => new ListarCabaniasDTO()
            {
                NumeroHabitacion = x.NumeroHabitacion,
                CantidadMaximaPersonas = x.CantidadMaximaPersonas,
                Nombre = x.Nombre.Valor,
                TipoCabania = x.TipoCabana.Nombre.Valor,
                CostoPorHuesped = x.TipoCabana.CostoPorHuesped,
                Descripcion = x.Descripcion,
                Jacuzzi = x.Jacuzzi,
                Habilitada = x.Habilitada,
                Foto = x.Foto,
                Mantenimientos = x.Mantenimientos.Select(x => new MantenimientoDTO()
                {
                    CostoMantenimiento = x.CostoMantenimiento,
                    FechaMantenimiento = x.FechaMantenimiento,
                    Descripcion = x.Descripcion.Valor,
                    Trabajador = x.Trabajador

                }).ToList()

            });
        }

        /// <summary>
        /// Metodo/Funcion que Obtiene el Listado de cabañas por cantidad maxima de persona
        /// </summary>
        /// <param name="cantidad"></param>
        /// <returns>Lista Cabaña</returns>

        [HttpGet("Max-Personas/{cantidad}")]
       
        public IEnumerable<ListarCabaniasDTO> ObtenerListaCabaniasPorMaxPersonas(int cantidad)
        {

            var cabanias = UcObtenerListaCabaniasPorMaxPersonas.Ejecutar(cantidad);
            return cabanias.Select(x => new ListarCabaniasDTO()
            {
                NumeroHabitacion = x.NumeroHabitacion,
                CantidadMaximaPersonas = x.CantidadMaximaPersonas,
                Nombre = x.Nombre.Valor,
                TipoCabania = x.TipoCabana.Nombre.Valor,
                CostoPorHuesped = x.TipoCabana.CostoPorHuesped,
                Descripcion = x.Descripcion,
                Jacuzzi = x.Jacuzzi,
                Habilitada = x.Habilitada,
                Foto = x.Foto,
                Mantenimientos = x.Mantenimientos.Select(x => new MantenimientoDTO()
                {
                    CostoMantenimiento = x.CostoMantenimiento,
                    FechaMantenimiento = x.FechaMantenimiento,
                    Descripcion = x.Descripcion.Valor,
                    Trabajador = x.Trabajador

                }).ToList()

            });
        }

        /// <summary>
        /// Metodo/Funcion que da de alta una cabañas
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Alta(AltaCabaniaDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                Cabania cabania = new Cabania()
                {
                    Nombre = NombreCabaniaVO.Crear(model.Nombre),
                    Descripcion = model.Descripcion,
                    Jacuzzi = model.Jacuzzi,
                    Habilitada = model.Habilitada,
                    CantidadMaximaPersonas = model.CantidadMaximaPersonas,
                    Foto = model.Foto,
                    secuenciador = 1,//TODO: ahora el secuenciador lo vamos a controlar en guardarimagen borrar 
                    TipoCabana = UcObtenerTipoPorId.Ejecutar(model.IdTipo)
                };
                UcAltaCabania.Ejecutar(cabania);
                model.Foto=cabania.Foto;//TODO: ver si funciona esto para cambiar el nombre de archivofoto
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }







    }
}
