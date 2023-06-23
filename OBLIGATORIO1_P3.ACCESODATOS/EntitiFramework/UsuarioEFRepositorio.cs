using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects;

namespace OBLIGATORIO1_P3.ACCESODATOS.EntitiFramework
{
    public class UsuarioEFRepositorio : IUsuarioRepositorio
    {

        ObligatorioContext context;
        public UsuarioEFRepositorio(ObligatorioContext Contexto)
        {
            this.context = Contexto;
        }

        
        public void Agregar(Usuario entidad)
        {
            if (entidad is null) throw new UsuarioException("datos de usuario incorrectos");
           
            try
            {
                
                context.Usuarios.Add(entidad);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UsuarioException(ex.Message);
            }
        }

   

        public Usuario? Obtener(string mail)
        {


            var obtener = this.context.Usuarios.AsEnumerable().FirstOrDefault(e=>e.Mail.Mail.Equals(mail));

            return obtener;
        }
    }
}
