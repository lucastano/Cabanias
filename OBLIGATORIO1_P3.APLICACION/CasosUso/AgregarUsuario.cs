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
    public class AgregarUsuario:IAgregarUsuario
    {
       private readonly IUsuarioRepositorio repositorio;

        public AgregarUsuario(IUsuarioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Ejecutar(Usuario entidad)
        {
            if (entidad == null) throw new UsuarioException("datos no validos");
            var usuarioDominio = repositorio.Obtener(entidad.Mail.Mail);
            if (usuarioDominio is not null) { 

            throw new UsuarioException("el usuario ya existe");
            
            } 
            this.repositorio.Agregar(entidad);
        }
    }
}
