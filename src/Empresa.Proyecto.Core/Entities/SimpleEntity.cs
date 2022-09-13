
namespace Empresa.Proyecto.Core.Entities
{
    /// <summary>
    /// Clase ejemplo para entidades simples, como un Catalogo
    /// </summary>
    /// <remarks>
    /// Borrar en la implementacion
    /// </remarks>
    public class SimpleEntity:BaseEntity
    {
        // inicianilazcion a null! para evitar el warning
        // causado por EF Core y su necesidad de tener un
        // constructor sin parametros

        //En C#8 es importante marcar los strings nulables para saber si son opcionales 
        // y si se permite nulo o siempre deberia traer valor

        public string Name { get; set; } = null!;
        public string? Value { get; set; } 
        
    }
}
