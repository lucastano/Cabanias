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
    public class AltaCabania:IAltaCabania
    {
        ICabaniaRepositorio repositorio;

        public AltaCabania(ICabaniaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Ejecutar(Cabania entidad)
        {
            if (entidad is null) throw new Exception("cabania no puede estar vacio");
            this.repositorio.Agregar(entidad);
        }
    }
}
