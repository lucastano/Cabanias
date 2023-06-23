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
    public class ObtenerListaMantenimientosCabaniaEntreFechas:IObtenerListaMantenimientosCabaniaEntreFechas
    {
        IMantenimientoRepositorio repositorio;

        public ObtenerListaMantenimientosCabaniaEntreFechas(IMantenimientoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public IEnumerable<Mantenimiento> Ejecutar(int idCabania, DateTime fechaDesde, DateTime fechaHasta)
        {
            if (idCabania == 0) throw new Exception("ID DE CABANIA INVALIDO");
            if (fechaDesde == DateTime.MinValue) throw new Exception("Debe ingresar fecha desde ");
            if (fechaHasta == DateTime.MinValue) throw new Exception("Debe ingresar fecha hasta ");

            return this.repositorio.MantenimientosDeCabaniaEntreFechas(idCabania,fechaDesde,fechaHasta);
        }
    }
}
