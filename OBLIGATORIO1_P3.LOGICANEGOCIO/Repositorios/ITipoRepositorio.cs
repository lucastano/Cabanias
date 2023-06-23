using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios
{
    public interface ITipoRepositorio
    {
        Tipo BuscarPorNombre(string nombre);
        void Actualizar(Tipo entidad);
        void Agregar(Tipo entidad);
        void Eliminar(int id);
        IEnumerable<Tipo> ObtenerTodos();
        Tipo? Obtener(int id);
        
    }
}
