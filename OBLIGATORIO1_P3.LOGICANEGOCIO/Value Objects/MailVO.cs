using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects
{
    public class MailVO:IEquatable<MailVO>
    {
        public string Mail { get; }

        private MailVO(string Mail) { 
        
        this.Mail = Mail;

        }

        public static MailVO Crear(string Mail)
        {
            if (Mail.Length == 0) throw new UsuarioException("no ingreso un mail");
            if (!Mail.Contains("@")) throw new UsuarioException("Mail no contiene @");
            if (!Mail.Contains(".com") && !Mail.Contains(".es")) throw new UsuarioException("Mail no contiene extencion");

            return new MailVO(Mail);



        }

        public bool Equals(MailVO? other)
        {
            if (other == null) 
            {

                return false;
            }

            return Mail.Equals(other.Mail);

        }
    }
}
