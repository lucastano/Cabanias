using Microsoft.EntityFrameworkCore;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades
{
    [Table("Usuarios")]
    [Index(nameof(Mail),IsUnique =true,Name ="MailIndex")]
    public class Usuario:IValidable
    {
        #region Propiedades
        public int Id { get; set; }
       
        public MailVO Mail { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public void Validar()
        {
           throw new NotImplementedException();
        }

        //private bool ValidaPass()
        //{
        //    bool retorno = true;
        //    if (this.Contrasena.Count() < 6) { retorno = false; }
        //    int contadorMinusculas = 0;
        //    int contadorMayusculas = 0;
        //    int contadorNumeros = 0;
        //    int i = 0;
        //    while (retorno && i < this.Contrasena.Count())
        //    {
        //        if (char.IsSeparator(this.Contrasena[i]) || char.IsPunctuation(this.Contrasena[i]) || char.IsSymbol(this.Contrasena[i]))
        //        {
        //            retorno = false;
        //        }
        //        if (char.IsUpper(this.Contrasena[i]))
        //        {
        //            contadorMayusculas++;
        //        }
        //        if (char.IsNumber(this.Contrasena[i]))
        //        {
        //            contadorNumeros++;
        //        }
        //        if (char.IsLower(this.Contrasena[i]))
        //        {
        //            contadorMinusculas++;
        //        }
        //        i++;
        //    }

        //    if (contadorMinusculas <= 0 && contadorMayusculas <= 0 && contadorNumeros <= 0 && retorno)
        //    {
        //        retorno = false;
        //    }


        //    return retorno;
        //}





        #endregion







    }
}
