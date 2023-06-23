using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;

namespace OBLIGATORIO1_P3.ACCESODATOS.EntitiFramework
{
    public class TipoEFRepositorio : ITipoRepositorio
    {
        ObligatorioContext context;
        public TipoEFRepositorio(ObligatorioContext context)
        {
            this.context = context;
        }
        public void Actualizar(Tipo entidad)
        {
            //EN MVC DEBEMOS BUSCARLO POR NOMBRE, EL USUARIO NO VE EL ID VER PUNTO 4 Inciso e
            // solo modifica descripcion y costo como pide letra 
            if (entidad is null) throw new TipoException("Tipo no existe");
            if (entidad.Id == 0) throw new TipoException("id no eixste");
            Tipo? actualizar = Obtener(entidad.Id);
            if (actualizar is null) throw new TipoException("No se encontro el tipo a modificar");
            if (actualizar.Id == 0) throw new TipoException("id incorrecto");
                       
            try
            {
                actualizar.Descripcion=entidad.Descripcion;
                actualizar.CostoPorHuesped = entidad.CostoPorHuesped;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new TipoException("Error al actualizar", ex);
            }
        }

        public void Agregar(Tipo entidad)
        {
            if (entidad is null) throw new TipoException("algun dato no fue ingresado");
            //retorna una lista de tipos con el mismo nombre que entidad
            var tipo = context.Tipos.Where(e => e.Nombre == entidad.Nombre).ToList();
            
            try
            {
                //verifica si el count de tipo es diferente a cero, significa que ya existe tipo con ese nombre 
                if (tipo.Count != 0) throw new TipoException("Ya existe un tipo con ese nombre");

                
                context.Tipos.Add(entidad);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new TipoException(ex.Message);
            }
        }

        public void Eliminar(int id)
        {
            

            try
            {
                if (id <= 0) throw new Exception("id incorrecto");
                Tipo? eliminar = Obtener(id);
                if (eliminar is null) throw new TipoException("error no se puede eliminar");

                var tieneCabanias=context.Cabanias.Where(c=>c.TipoCabana.Id==eliminar.Id).ToList();
                if (tieneCabanias.Count() > 0) throw new TipoException("Este tipo de cabania esta asociado a una cabaña");

                context.Tipos.Remove(eliminar);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new TipoException(ex.Message);
            }
        }

        public Tipo? Obtener(int id)
        {
            return context.Tipos.Find(id);
        }
       

        public IEnumerable<Tipo> ObtenerTodos()
        {
            return context.Tipos;
        }

        public Tipo? BuscarPorNombre(string nombre)//busca por nombre
        {
            return context.Tipos.FirstOrDefault(x => x.Nombre.Valor == nombre);            

        }
    }
}
