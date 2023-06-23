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
    public class AltaTipo : IAltaTipo
    {
        ITipoRepositorio repositorio;
        public AltaTipo(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Ejecutar(Tipo entidad)
        {
            if (entidad is null) throw new Exception("no ingreso datos");
            repositorio.Agregar(entidad);
            
        }
    }
}
