using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones
{
    public class TipoException : Exception
    {
        public TipoException() { }
        public TipoException(string message) : base(message) { }    
        public TipoException(string mensaje, Exception ex) : base(mensaje) { }
    }
}
