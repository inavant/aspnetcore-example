using System.Linq.Expressions;

namespace Empresa.Proyecto.Core.Interfaces
{
    /// <summary>
    /// Representa la definicion de una especificacion, para poder filtrar y manipular una entidad generica en el repositorio
    /// </summary>
    /// <typeparam name="T">Valor de tipo Entidad al que se busca manipular</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Expresion de Linq para filtrar la entidad <typeparamref name="T"/>
        /// </summary>
        Expression<Func<T, bool>> Criteria { get; }
        /// <summary>
        /// Coleccion de propiedades de navegacion de la entidad para que se incluyan en la carga de datos
        /// Ej. Colecciones de entidades hijas, multicatalogos, etc.
        /// </summary>
        List<Expression<Func<T, object>>> Includes { get; }
        /// <summary>
        /// Coleccion de entidades a incluir, como texto simple
        /// </summary>
        List<string> IncludeStrings { get; }
        /// <summary>
        /// Propiedad por la cual debe ordenarse la coleccion, <c>en modo ascendente (default)</c>.
        /// </summary>
        Expression<Func<T, object>> OrderBy { get; }
        /// <summary>
        /// Propiedad por la cual debe ordenarse la coleccion, <c>en modo descendnete (default)</c>.
        /// </summary>
        Expression<Func<T, object>> OrderByDescending { get; }
        /// <summary>
        /// Entidad por la cual debe ordenarse la coleccion, <c>en modo ascendente (default)</c>.
        /// </summary>
        Expression<Func<T, object>> GroupBy { get; }
        /// <summary>
        /// Cantidad de elementos a obtener en la consulta
        /// </summary>
        int Take { get; }
        /// <summary>
        /// Cantidad de elementos que debe saltarse la consulta. Normalmente es la pagina 
        /// actual por la cantidad de elementos, para obtener el siguiente set de resultados
        /// </summary>
        int Skip { get; }
        /// <summary>
        /// Indica si se debe paginar o no la especificacion
        /// </summary>
        bool IsPagingEnabled { get; }
    }
}
