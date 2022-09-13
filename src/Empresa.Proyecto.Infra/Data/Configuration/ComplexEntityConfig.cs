using Microsoft.EntityFrameworkCore;
using Empresa.Proyecto.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Proyecto.Infra.Data.Configuration
{
    internal class ComplexEntityConfig : IEntityTypeConfiguration<ComplexEntity>
    {
        public void Configure(EntityTypeBuilder<ComplexEntity> builder)
        {
            // Podemos ayudar a EF a definir correctamente un arelacion si es necesario
            // Normalmetne hace un buen trabajo entocnes solo especificar para forzar la 
            // relacion a que funione como queremos

            //builder.HasOne(c => c.CatalogExample)
            //    .WithMany()
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);

            // En C#8 las propiedades requeridas se infieren si el tipo es nullable.
            // Versiones anteriores acpetan nulo por default en string por lo tanto habia que 
            // marcarlos explicitamente como requeridos

            builder.Property(c => c.Title)
            //    .IsRequired();
                .HasMaxLength(250);

            builder.Property(c => c.Description)
                .HasMaxLength(1000);

            builder.Property(c => c.Amount)
                .HasColumnType("decimal(12,2)");
        }
    }
}
