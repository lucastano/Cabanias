using OBLIGATORIO1_P3.APLICACION.InterfacesCasoUso;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.APLICACION.CasosUso
{
    public class ObtenerTodosTipos : IObtenerTodosTipos
    {
        ITipoRepositorio repositorio;
        public ObtenerTodosTipos(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public IEnumerable<Tipo> Ejecutar()
        {
            return repositorio.ObtenerTodos();
        }
    }
}
