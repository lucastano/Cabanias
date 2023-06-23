using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones
{
    public class UsuarioException :Exception
    {
        public UsuarioException() { }
        public UsuarioException(string message) : base(message) { }
        public UsuarioException(string mensaje, Exception ex) : base(mensaje) { }
    }
}
