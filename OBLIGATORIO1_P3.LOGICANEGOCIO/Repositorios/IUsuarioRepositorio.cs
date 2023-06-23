using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios
{
    public interface IUsuarioRepositorio
    {
        void Agregar(Usuario entidad);
        Usuario? Obtener(string mail);


    }
}
