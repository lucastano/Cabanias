using OBLIGATORIO1_P3.APLICACION.InterfacesCasoUso;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.APLICACION.CasosUso
{
    public class EliminarTipo : IEliminarTipo
    {
        ITipoRepositorio repositorio;

        public EliminarTipo(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Ejecutar(int id)
        {
            if (id == 0) throw new Exception("ID INCORRECTO");
            this.repositorio.Eliminar(id);
            
        }
    }
}
