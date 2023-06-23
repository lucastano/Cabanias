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
    public class ObtenerListaCabaniasTipo:IObtenerListaCabaniasTipo
    {
        ICabaniaRepositorio repositorio;
        public ObtenerListaCabaniasTipo(ICabaniaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Cabania> Ejecutar(int IdTipo)
        {
            if (IdTipo <=0) throw new Exception("tipo no puede ser vacio");
            return this.repositorio.CabaniasPorTipo(IdTipo); // no se si se utiliza obtenerCabaniasPorTipo o esta
        }
    }
}
