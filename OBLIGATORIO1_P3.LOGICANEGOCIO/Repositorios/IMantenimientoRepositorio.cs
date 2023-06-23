using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios
{
    public interface IMantenimientoRepositorio
    {
        Cabania ObtenerCabaniaPorId(int id);

        IEnumerable<Mantenimiento> MantenimientosDeCabaniaEntreFechas(int idCabania, DateTime fechaDesde, DateTime fechaHasta);

        IEnumerable<Mantenimiento> MantenimientosPorCabania(int idCabania);

        void Agregar(Mantenimiento entidad);

        List<Mantenimiento> Obtener(Cabania cabania);

        IEnumerable<Mantenimiento> ObtenerTodos();

        bool verificarSiTieneMaximoMantenimientos(Cabania cabania, DateTime fecha);
    }
}
