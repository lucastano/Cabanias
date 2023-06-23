using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios
{
    public interface ICabaniaRepositorio
    {
        List<Tipo> ObtenerTiposId();


        List<Cabania> ObtenerCabaniaPorNombre(string nombre);
        List<Cabania> PorCantidadMaximaPersonas(int cantidad);

        List<Cabania> CabaniasHabilitadas();

        List<Cabania> CabaniasPorTipo(int id);

        Cabania? Obtener(int numeroHabitacion);

        //estas estaban en irepositorio
        void Agregar(Cabania entidad);
        void Actualizar(Cabania entidad);
        void Eliminar(int id);

        IEnumerable<Cabania> ObtenerTodos();

        IEnumerable<Cabania> ObtenerPorTipoYMonto(int tipo, int monto);
        IEnumerable<MantenimientosPorValor> ObtenerMantenimientosPorValores(int cantidadDesde, int cantidadHasta);


    }
}
