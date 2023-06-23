using OBLIGATORIO1_P3.APLICACION.InterfacesCasoUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.APLICACION.CasosUso
{
    public class ValidarPassword : IValidarPassword
    {
        public bool Ejecutar(string password)
        {
            bool retorno = true;
            if (password.Count() < 6) { retorno = false; }
            int contadorMinusculas = 0;
            int contadorMayusculas = 0;
            int contadorNumeros = 0;
            int i = 0;
            while (retorno && i < password.Count())
            {
                if (char.IsSeparator(password[i]) || char.IsPunctuation(password[i]) || char.IsSymbol(password[i]))
                {
                    retorno = false;
                }
                if (char.IsUpper(password[i]))
                {
                    contadorMayusculas++;
                }
                if (char.IsNumber(password[i]))
                {
                    contadorNumeros++;
                }
                if (char.IsLower(password[i]))
                {
                    contadorMinusculas++;
                }
                i++;
            }

            if (contadorMinusculas <= 0 && retorno || contadorMayusculas <= 0 && retorno || contadorNumeros <= 0 && retorno)
            {
                retorno = false;
            }


            return retorno;
        }
       


    }
}
