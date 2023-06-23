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
    public class TipoPorNombre:ITipoPorNombre
    {
        ITipoRepositorio repositorio;

        public TipoPorNombre(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Tipo Ejecutar(string nombre)
        {
            if (nombre == "") throw new Exception("El nombre no puede ser vacio");
            return this.repositorio.BuscarPorNombre(nombre);

        }
    }
}
