using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects
{
    public class NombreCabaniaVO:IEquatable<NombreCabaniaVO>
    {

        public string Valor { get; } //TODO: tengo que cambiarlo a mayuscula V


        private NombreCabaniaVO(string nombre) {
        
            this.Valor = nombre;
        
        }

        public static NombreCabaniaVO Crear(string nombre)
        {
            //validaciones
            
                if(ValidarNombreVacio(nombre)) throw new CabaniaException("El nombre esta vacio");
                if (ValidarNombre(nombre)) throw new CabaniaException("El nombre contiene espacios al principio y/o al final o puede contener numeros, Verifique");
                return new NombreCabaniaVO(nombre);
        }

        public bool Equals(NombreCabaniaVO? other)
        {
            if(other == null) return false;
            return Valor.Equals(other.Valor);
        }

        private static bool ValidarNombre(string valor)
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



        
        private static  bool ValidarNombreVacio(string valor)
        {
            return string.IsNullOrEmpty(valor);
        }


    }
}
