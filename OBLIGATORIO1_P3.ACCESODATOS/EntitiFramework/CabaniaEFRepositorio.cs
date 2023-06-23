using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;

using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using Xunit.Sdk;

namespace OBLIGATORIO1_P3.ACCESODATOS.EntitiFramework
{
    public class CabaniaEFRepositorio : ICabaniaRepositorio
    {
        ObligatorioContext context;
        public CabaniaEFRepositorio(ObligatorioContext Contexto)
        {
            this.context = Contexto;
        }
        public void Actualizar(Cabania entidad)
        {
            if (entidad is null) throw new CabaniaException("no se puede actualizar");
            Cabania? modificar = Obtener(entidad.NumeroHabitacion);
            if (modificar is null) throw new CabaniaException("no se encontro cabaña");

            try
            {
                modificar.Nombre = entidad.Nombre;
            }
            catch (Exception ex)
            {
                throw new CabaniaException("Error al modificar", ex);
            }
        }

        public void Agregar(Cabania entidad)
        {
            if (entidad is null) throw new CabaniaException("no se puede agregar");
            entidad.Validar();
            var cabania = context.Cabanias.Where(e => e.Nombre == entidad.Nombre);

            try
            {
                if (cabania.Count() > 0) throw new CabaniaException("Ya existe una cabania con ese nombre");
                context.Cabanias.Add(entidad);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CabaniaException(ex.Message);
            }

        }
        
        //No se usa pero de todas formas se planteo 
        public void Eliminar(int numeroHabitacion)
        {
            if (numeroHabitacion <= 0) throw new CabaniaException("Autor ID no puede ser cero o negativo.");
            var habitacionDB = Obtener(numeroHabitacion);
            if (habitacionDB is null) throw new CabaniaException("Autor no encontrado");

            try
            {
                context.Cabanias.Remove(habitacionDB);
                context.Remove(habitacionDB);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CabaniaException("Error al eliminar", ex);
            }
        }
      

        
        public Cabania? Obtener(int numeroHabitacion)
        {
         return context.Cabanias.FirstOrDefault(c => c.NumeroHabitacion == numeroHabitacion);
            
        }
        public IEnumerable<Cabania> ObtenerTodos()
        {
            return context.Cabanias.Include(e => e.TipoCabana).Include(e=>e.Mantenimientos);
        }
        //en interface CREO QUE NO SE USA , VERIFICAR
        public List<Tipo> ObtenerTiposId()
        {
            var t = context.Tipos.Select(t => t);
            return t.ToList();
            
        }

        //devuelve cabanias que contenga el string pasado por parametros en su nombre 
        public List<Cabania> ObtenerCabaniaPorNombre(string nombre)
        {
         return context.Cabanias.Include(c => c.TipoCabana).Include(e => e.Mantenimientos).AsEnumerable().Where(c => c.Nombre.Valor.Contains(nombre)).ToList();
        }
        

        
        public List<Cabania> PorCantidadMaximaPersonas(int cantidad) 
        {
            return context.Cabanias.Include(c=>c.TipoCabana).Where(c => c.CantidadMaximaPersonas >= cantidad).Include(e=>e.Mantenimientos).ToList();
        
        }
        //en interface
        public List<Cabania> CabaniasHabilitadas() 
        {
         return context.Cabanias.Include(c=>c.TipoCabana).Include(c=>c.Mantenimientos).Where(c => c.Habilitada == true).ToList();
        }

       

        //en interface NO SE USA, VERIFICAR
        public List<Cabania> CabaniasPorTipo(int id)
        {
            List<Cabania> cabanias=context.Cabanias.Include(c=>c.TipoCabana).Include(c=>c.Mantenimientos).Where(c=>c.TipoCabana.Id==id).ToList();

            return cabanias;
        }

        //TODO: EJERCIOCIO 6 PROBARLO BIEN SEGUN DATOS 
        //punto 6a
        public IEnumerable<Cabania> ObtenerPorTipoYMonto(int idTipo, int monto)
        {
            if (idTipo < 0 || monto < 0) throw new CabaniaException("El nombre y la cantidad no puede estar vacias");
            try
            {
                return context.Cabanias.Include(c => c.TipoCabana).Where(c => c.TipoCabana.Id == idTipo && c.TipoCabana.CostoPorHuesped < monto && c.Jacuzzi == true && c.Habilitada == true).ToList();
            }
            catch (Exception ex)
            {



                throw new CabaniaException("Error al listar", ex);



            }
        }
        
        //TODO: falta esta funcion en uml
        public IEnumerable<MantenimientosPorValor> ObtenerMantenimientosPorValores(int cantidadDesde ,int cantidadHasta) 
        {

            var mantenimientos = context.Mantenimientos.Include(e => e.Cabania).Where(e => e.Cabania.CantidadMaximaPersonas >= cantidadDesde && e.Cabania.CantidadMaximaPersonas <= cantidadHasta).GroupBy(e => e.Trabajador).Select(e => new MantenimientosPorValor
            {
                NombreTrabajador = e.Key,
                TotalMantenimientos = e.Sum(x => x.CostoMantenimiento)

            }).ToList(); ;



            return mantenimientos;



        }
    }
}
 