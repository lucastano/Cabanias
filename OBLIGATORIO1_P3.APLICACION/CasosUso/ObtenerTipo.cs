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
    public class ObtenerTipo : IObtenerTipo
    {
        ITipoRepositorio repositorio;
        public ObtenerTipo(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Tipo? Ejecutar(int id)
        {
            if (id == 0) throw new Exception("ESTE ID NO EXISTE");
            return this.repositorio.Obtener(id);
        }
    }
}
