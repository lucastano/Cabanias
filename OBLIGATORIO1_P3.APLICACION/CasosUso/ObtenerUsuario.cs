using OBLIGATORIO1_P3.APLICACION.InterfacesCasoUso;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.APLICACION.CasosUso
{
    public class ObtenerUsuario : IObtenerUsuario
    {
        IUsuarioRepositorio repositorio;

        public ObtenerUsuario(IUsuarioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Usuario? Ejecutar(string mail)
        {
            

            return repositorio.Obtener(mail);
        }
    }
}
