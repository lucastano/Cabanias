using Microsoft.EntityFrameworkCore;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.ACCESODATOS.EntitiFramework
{
    public class MantenimientoEFRepositorio:IMantenimientoRepositorio
    { 
        ObligatorioContext context;
        public MantenimientoEFRepositorio(ObligatorioContext Contexto)
        {
            this.context = Contexto;
        }

       

        public void Agregar(Mantenimiento entidad)
        {
            if (entidad is null) throw new MantenimientoException("No se puede agregar");           
            entidad.Validar();
            
            if (verificarSiTieneMaximoMantenimientos(entidad.Cabania, entidad.FechaMantenimiento)) throw new Exception("Mantenimientos diarios superados");
           
            try
            {                
                context.Mantenimientos.Add(entidad);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new MantenimientoException("Error al agregar", ex);
            }
        }
       

       

        

        public List<Mantenimiento> Obtener(Cabania cabania)
        {
            return context.Mantenimientos.Where(c => c.Cabania == cabania).Include(c=>c.Cabania).ToList();
        }
        public IEnumerable<Mantenimiento> ObtenerTodos()
        {
            return context.Mantenimientos;
        }

        
        public bool verificarSiTieneMaximoMantenimientos(Cabania cabania, DateTime fecha)
        {
            bool retorno = false;

            var mantenimientos = context.Mantenimientos.Where(e => e.cabaniaCodigo == cabania.NumeroHabitacion && e.FechaMantenimiento == fecha).ToList();
            

            if (mantenimientos.Count >= 3)
            {
                retorno= true;
            }

            return retorno;

        }

        ///
        //public List<Mantenimiento> ObtenerPorFechas(DateTime fecha1, DateTime fecha2)
        //{
        //    return context.Mantenimientos.Where(c => c.FechaMantenimiento >= fecha1 && c.FechaMantenimiento<=fecha2).OrderByDescending(c => c.CostoMantenimiento).ToList();
        //}

        // poner en interface ImantenimientoRepositorio ? 
        public Cabania ObtenerCabaniaPorId(int id)
        {
            
            
            var cabania=context.Cabanias.ToList().FirstOrDefault(c=>c.NumeroHabitacion==id);
            

            return cabania;
        }

        public IEnumerable<Mantenimiento> MantenimientosDeCabaniaEntreFechas(int idCabania, DateTime fechaDesde, DateTime fechaHasta)
        {
            var listado=context.Mantenimientos.Include(e=>e.Cabania).Where(e=>e.cabaniaCodigo==idCabania && e.FechaMantenimiento>=fechaDesde && e.FechaMantenimiento<=fechaHasta).OrderByDescending(e=>e.CostoMantenimiento).ToList();
            return listado;
        }

        public IEnumerable<Mantenimiento> MantenimientosPorCabania(int idCabania)
        {
            return context.Mantenimientos.Where(e=>e.cabaniaCodigo== idCabania).OrderBy(e=>e.FechaMantenimiento).ToList();
        }

        
    }
}
