using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Validaciones;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;
using Xunit;
using Xunit.Sdk;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades
{
    [Table("Tipo")]
    [Index(nameof(Nombre),IsUnique = true, IsDescending = new[] { true }, Name = "UX_TIPO_NOMBRE")]
    public class Tipo 
    {

        #region Propiedades
        public int Id { get; set; }
        public NombreTipoVO Nombre { get; set; }
        
        

        [StringLength(200, MinimumLength = 10, ErrorMessage = "Debe tener entre 10 y 200 caracteres ")]
        public string Descripcion { get; set; }

        [DisplayFormat(DataFormatString ="{0:#.####}")]
        public double CostoPorHuesped { get; set; }
        #endregion

        #region Validaciones
        

        
       

        #endregion
    }
}
