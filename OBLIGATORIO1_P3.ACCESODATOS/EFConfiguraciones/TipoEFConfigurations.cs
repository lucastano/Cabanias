using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects;

namespace OBLIGATORIO1_P3.ACCESODATOS.EFConfiguraciones
{
    public class TipoEFConfigurations : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.Property(e => e.Nombre)
                .HasConversion(
                v=>v.Valor,
                v=>NombreTipoVO.Crear(v)
                );
        }
    }
}
