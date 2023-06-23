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
    public class ObtenerCabaniaPorTipoYMonto:IObtenerCabaniaPorTipoYMonto
    {
        ICabaniaRepositorio repositorio;

        public ObtenerCabaniaPorTipoYMonto(ICabaniaRepositorio repositorio)
        {
            this.repositorio = repositorio;

        }

        public IEnumerable<Cabania> Ejecutar(int tipo,int monto)
        {

            return repositorio.ObtenerPorTipoYMonto(tipo, monto);


        }
    }
}
