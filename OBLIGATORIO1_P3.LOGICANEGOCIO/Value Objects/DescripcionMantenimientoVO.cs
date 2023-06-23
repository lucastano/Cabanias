using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects
{
    public class DescripcionMantenimientoVO:IEquatable<DescripcionMantenimientoVO>
    {
        public string Valor { get; }

        private DescripcionMantenimientoVO(string Valor) {
        
        this.Valor = Valor;

        }

        public static DescripcionMantenimientoVO Crear(string descripcion)
        {
            //aca van las validaciones 

            int largoCadena=descripcion.Length;
            if (largoCadena < 10) throw new MantenimientoException("La descripcion debe ser mayor a 10 caracteres");
            if (largoCadena > 200) throw new MantenimientoException("La descripcion no puede superar los 200 caracteres");

            return new DescripcionMantenimientoVO(descripcion);
        }

        public bool Equals(DescripcionMantenimientoVO? other)
        {
            if (other == null) return false;
            return Valor.Equals(other.Valor);
        }
    }
}
