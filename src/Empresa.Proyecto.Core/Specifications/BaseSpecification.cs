using Empresa.Proyecto.Core.Interfaces;
using System.Linq.Expressions;


namespace Empresa.Proyecto.Core.Specifications
{
    /// <summary>
    /// Clase base para crear una especificacion que permita filtrar 
    /// los elementos a buscar de una entidad
    /// </summary>
    /// <remarks>EF Core ahora incluye propiedades de navegacion requeridas, por loq ue solo es necesario crear especificaciones
    /// con includes para propiedades opcionales</remarks>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        /// <summary>
        /// Inicaliza la especificacion para situacion que no necesitan un filtro especifico.
        /// Ej. Solo agregar includes para llenar propiedades de navegacion opcionales
        /// </summary>
        /// <example></example>
        protected BaseSpecification()
        {

        }

        /// <summary>
        /// Inicializa la especificacion con los datos para filtrar
        /// </summary>
        /// <param name="criteria">Expresion linq para determinar el (los) filtros a implementar en el query</param>
        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        
        /// <summary>
        /// Expresion de Linq para filtrar la entidad <typeparamref name="T"/>
        /// </summary>
        public Expression<Func<T, bool>> Criteria { get; } = null!;
        /// <summary>
        /// Coleccion de propiedades de navegacion de la entidad para que se incluyan en la carga de datos
        /// Ej. Colecciones de entidades hijas, multicatalogos, etc.
        /// </summary>
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        /// <summary>
        /// Coleccion de entidades a incluir, como texto simple
        /// </summary>
        public List<string> IncludeStrings { get; } = new List<string>();
        /// <summary>
        /// Propiedad por la cual debe ordenarse la coleccion, <c>en modo ascendente (default)</c>.
        /// </summary>
        public Expression<Func<T, object>> OrderBy { get; private set; } = null!;
        /// <summary>
        /// Propiedad por la cual debe ordenarse la coleccion, <c>en modo descendnete (default)</c>.
        /// </summary>
        public Expression<Func<T, object>> OrderByDescending { get; private set; } = null!;
        
        /// <summary>
        /// Cantidad de elementos a obtener en la consulta
        /// </summary>
        public int Take { get; private set; }
        /// <summary>
        /// Cantidad de elementos que debe saltarse la consulta. Normalmente es la pagina 
        /// actual por la cantidad de elementos, para obtener el siguiente set de resultados
        /// </summary>
        public int Skip { get; private set; }       
        /// <summary>
        /// Indica si se debe paginar o no la especificacion
        /// </summary>
        public bool IsPagingEnabled { get; private set; } = false;
        /// <summary>
        /// Agrega una propiedad compleja de la entidad <typeparamref name="T"/> para que sea llenada tambien en el query
        /// </summary>
        /// <param name="includeExpression">Expresion lambda de la propiedad</param>
        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        /// <summary>
        /// Agrega una propiedad compljea de la entidad <typeparamref name="T"/> en formato de texto
        /// </summary>
        /// <remarks>Se recomienda usar AddInclude siempre que sea posible</remarks>
        /// <param name="includeString">cadena a incluir en la coleccion</param>
        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
        /// <summary>
        /// Aplica paginacion a la consulta. Considerar que el orden debe ser el mismo entre consultas
        /// </summary>
        /// <param name="skip">Cantidad de elementos a ignorar</param>
        /// <param name="take">Cantidad de elmentos a regresar (tamaño de pagina)</param>
        protected virtual void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
        /// <summary>
        /// Aplica un criterio para ordenar la entidad, de manera ascendente
        /// </summary>
        /// <param name="orderByExpression">Propiedad de la entidad a ordenar</param>
        protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        /// <summary>
        /// Aplica un criterio para ordenar la entidad, de manera descendente
        /// </summary>
        /// <param name="orderByDescendingExpression">Propiedad de la entidad a ordenar</param>
        protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        // No usado actualmente. Ejemplo, pero en nuestro caso una neciesdiad de agrupar
        // probablemente sea mejor crear un servicio / repo especifico si tenemos
        // algo d esta complejdiad

        /// <summary>
        /// Entidad por la cual debe ordenarse la coleccion, <c>en modo ascendente (default)</c>.
        /// </summary>
        public Expression<Func<T, object>> GroupBy { get; private set; } = null!;
        /// <summary>
        /// Aplica una epxresion para agrupar los resultados.
        /// </summary>
        /// <remarks>
        /// No usado actualmente. Considerar si es mejor crear un DTO y/o
        /// un repositorio especifico para implmeentar un query con este nivel de complejidad
        /// </remarks>
        /// <param name="groupByExpression">Propiedad por la cual debe realizarse la agrupacion</param>
        protected virtual void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }

    }
}

