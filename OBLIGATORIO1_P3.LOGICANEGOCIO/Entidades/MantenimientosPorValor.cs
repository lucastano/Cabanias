using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades
{
    [NotMapped]
    public class MantenimientosPorValor
    {

        public string NombreTrabajador { get; set; }

        public double TotalMantenimientos { get; set; }

    }
}
