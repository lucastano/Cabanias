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
    public class ObtenerListaMantenimientosCabania:IObtenerListaMantenimientosCabania
    {
        IMantenimientoRepositorio repositorio;
        public ObtenerListaMantenimientosCabania(IMantenimientoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public IEnumerable<Mantenimiento> Ejecutar(int idCabania)
        {
            if (idCabania <= 0) throw new Exception("ID DE CABANIA NO EXISTE");

            return this.repositorio.MantenimientosPorCabania(idCabania);
        }
    }
}
