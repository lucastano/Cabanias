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
    public class AltaMantenimiento:IAltaMantenimiento
    {
        IMantenimientoRepositorio repositorio;

        public AltaMantenimiento( IMantenimientoRepositorio repositorio)
        {
            this.repositorio=repositorio;
        }

        public void Ejecutar(Mantenimiento entidad)
        {
            if (entidad == null) throw new Exception("Mantenimiento no puede ser vacio");
            this.repositorio.Agregar(entidad);
        }
    }
}
