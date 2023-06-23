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
    internal class CabaniaEFConfigurations : IEntityTypeConfiguration<Cabania>
    {
        public void Configure(EntityTypeBuilder<Cabania> builder)
        {
            builder.Property(e => e.Nombre)
                .HasConversion(
                v => v.Valor,
                v => NombreCabaniaVO.Crear(v)
                );
        }
    }
}
