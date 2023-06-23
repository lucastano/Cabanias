using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.ACCESODATOS.EFConfiguraciones
{
    public class MantenimientoEFConfigurations : IEntityTypeConfiguration<Mantenimiento>
    {
        public void Configure(EntityTypeBuilder<Mantenimiento> builder)
        {
            builder.Property(e => e.Descripcion)
                .HasConversion(
                v => v.Valor,
                v => DescripcionMantenimientoVO.Crear(v));
        }
    }


}
