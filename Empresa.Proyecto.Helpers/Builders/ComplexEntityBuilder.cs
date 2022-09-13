using Empresa.Proyecto.Core.Entities;

namespace Empresa.Proyecto.Test.Builders
{
    public class ComplexEntityBuilder
    {
        private readonly ComplexEntity complexEntity;

        public ComplexEntityBuilder()
        {
            complexEntity = new ComplexEntity();
        }


        public ComplexEntityBuilder Amount(decimal amount)
        {
            complexEntity.Amount = amount;
            return this;
        }

        public ComplexEntityBuilder WithDefaultValues() {
            complexEntity.Title = "Entidad X";
            complexEntity.Description = "neuva entidad con cierta capcidad de almacenamiento";
            complexEntity.Amount = 200m;
            complexEntity.CatalogExample = new SimpleEntity { Name = "Tipo A", Value="A" };

            return this;
        }

        public ComplexEntity Build() => complexEntity;
    }
}
