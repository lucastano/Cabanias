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
    public class EditarTipo : IEditarTipo
    {
        ITipoRepositorio repositorio;

        public EditarTipo(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }   

        public void Ejecutar(Tipo entidad)
        {
            if (entidad == null) throw new Exception("no existe este tipo de cabania");
            this.repositorio.Actualizar(entidad);
        }
    }
}
