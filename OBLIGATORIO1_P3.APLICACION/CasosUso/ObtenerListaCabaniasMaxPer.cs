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
    public class ObtenerListaCabaniasMaxPer:IObtenerListaCabaniasMaxPer
    {
        ICabaniaRepositorio repositorio;
        public ObtenerListaCabaniasMaxPer(ICabaniaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Cabania> Ejecutar(int cantidad)
        {
            if (cantidad < 1) throw new Exception("cantidad debe ser mayor a 0");

            return this.repositorio.PorCantidadMaximaPersonas(cantidad);
        }
    }
}
