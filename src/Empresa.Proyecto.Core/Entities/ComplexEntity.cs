namespace Empresa.Proyecto.Core.Entities
{
    /// <summary>
    /// Ejemplo de entidad compleja, como una entidad principal en dominio 
    /// con multiples campos e interacciones con otras entidades mas simples
    /// </summary>
    public class ComplexEntity:BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public SimpleEntity CatalogExample { get; set; } = null!;
        public decimal Amount { get; set; }

        public decimal Tax { get { return Math.Round((Amount * 0.16m), 2); } }
    }
}
