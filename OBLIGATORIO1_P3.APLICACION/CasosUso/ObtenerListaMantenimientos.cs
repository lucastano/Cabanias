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
    public class ObtenerListaMantenimientos:IObtenerListaMantenimientos
    {
        IMantenimientoRepositorio repositorio;

        public ObtenerListaMantenimientos(IMantenimientoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public IEnumerable<Mantenimiento> Ejecutar()
        {
            return this.repositorio.ObtenerTodos();
        }
    }
}
