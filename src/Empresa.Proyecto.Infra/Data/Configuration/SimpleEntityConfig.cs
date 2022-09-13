using Microsoft.EntityFrameworkCore;
using Empresa.Proyecto.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Proyecto.Infra.Data.Configuration
{
    internal class SimpleEntityConfig : IEntityTypeConfiguration<SimpleEntity>
    {
        public void Configure(EntityTypeBuilder<SimpleEntity> builder)
        {
            // En C#8 las propiedades requeridas se infieren si el tipo es nullable.
            // Versiones anteriores acpetan nulo por default en string por lo tanto habia que 
            // marcarlos explicitamente como requeridos

            builder.Property(e => e.Name)
            //    .IsRequired();
                .HasMaxLength(250);
        }
    }
}
