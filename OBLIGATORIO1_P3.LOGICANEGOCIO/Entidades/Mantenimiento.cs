using OBLIGATORIO1_P3.LOGICANEGOCIO.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades
{
    [Table("Mantenimiento")]
    public class Mantenimiento:IValidable
    {
        #region Propiedades
        public int Id { get; set; }
        public DateTime FechaMantenimiento { get; set; }
        
       
        [Required(ErrorMessage ="Debe ingresar una descripcion del mantenimiento")]
        public DescripcionMantenimientoVO Descripcion { get; set; }

        [Range(0,int.MaxValue)]
        public double CostoMantenimiento { get; set; }
        
        [Display(Name ="Nombre de Trabajador")]
        [Required(ErrorMessage ="Debe ingresar el nombre del trabajador")]
        public string Trabajador { get; set; }

        [Display(Name = "Cabaña")]

        [ForeignKey(nameof(Cabania))]
        public int cabaniaCodigo { get; set; }
        public Cabania Cabania { get; set; }
        #endregion

        #region Validaciones
        public void Validar()
        {
            if (!ValidarFecha()) throw new MantenimientoException("Fecha de mantenimiento debe ser menor a la fecha actual");
           
         



        }

        private bool ValidarFecha()
        {
            bool validacion = true;
            if (FechaMantenimiento >= DateTime.Now)
            {
                validacion = false;

            }
            return validacion;
        }
        
        #endregion
    }
}
