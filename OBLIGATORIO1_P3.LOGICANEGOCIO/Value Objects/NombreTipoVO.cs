using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects
{
    public class NombreTipoVO : IEquatable<NombreTipoVO>
    {
        public string Valor { get; }

        private NombreTipoVO(string nombre) 
        {
        this.Valor = nombre;
        
        }

        public static NombreTipoVO Crear(string nombre)
        {
            //TODO: aca van las validaciones FALTAN
            if (ValidarNombreVacio(nombre)) throw new TipoException("Nombre igresado es vacio");
            if (ValidarNombre(nombre)) throw new TipoException("Nombre igresado tiene espacios al principio y/o al final y/o numeros");
            return new NombreTipoVO(nombre);
        }

        public bool Equals(NombreTipoVO? other)
        {
            if (other == null) return false;
            return Valor.Equals(other.Valor);
        }

        private static bool ValidarNombreVacio(string valor)
        {
            return string.IsNullOrEmpty(valor);
        }

        public static bool ValidarNombre(string valor)
        {
            bool esNumero = false;
            string nombre = valor;
            int i = 0;
            while (!esNumero && i < nombre.Length)
            {

                if (i < 1 || i >= nombre.Length-1)
                {
                    if (char.IsNumber(nombre[i]) || char.IsSeparator(nombre, i))
                    {
                        esNumero = true;

                    }
                }
                else
                {

                    if (!char.IsLetter(nombre[i]))
                    {
                        if (!char.IsSeparator(nombre, i))
                        {
                            esNumero = true;

                        }


                    }


                }
                i++;

            }
            return esNumero;
        }


       
    }
}
