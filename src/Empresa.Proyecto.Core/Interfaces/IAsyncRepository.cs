using Empresa.Proyecto.Core.Entities;

namespace Empresa.Proyecto.Core.Interfaces
{
    /// <summary>
    /// Interfaz base generica de los repositorios asincronos del proyecto
    /// </summary>
    /// <typeparam name="T">Tipo de dato de los Elementos que regresa la coleccion</typeparam>
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Obtiene un elemento por su llave primaria ID
        /// </summary>
        /// <param name="id">Id del elemento a obtener</param>
        /// <returns>Elemento</returns>
        Task<T?> GetbyIdAsync(int id);

        /// <summary>
        /// Obtiene un elemento utilizando un ISpecification
        /// </summary>
        /// <param name="spec">Specitifaction de filtro</param>
        /// <returns>Elemento</returns>
        Task<T?> GetAsync(ISpecification<T> spec);

        /// <summary>
        /// Listado de todos los elementos del repositorio
        /// </summary>
        /// <returns>Lista solo lectura de elementos</returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// Listado de los elementos del repositorio filtrados por una condicion
        /// </summary>
        /// <param name="spec">Especificacion para filtarar u ordenar los elementos</param>
        /// <returns>Lista solo lectura de elementos</returns>
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);


        /// <summary>
        /// Agregar entidad al repositorio
        /// </summary>
        /// <param name="entity">Entidad</param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Actualiza una entidad al repositorio
        /// </summary>
        /// <param name="entity">Entidad</param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Elimina una entidad del repositorio
        /// </summary>
        /// <param name="entity">Entidad</param>
        /// <returns></returns>
        Task DeleteAsync(T entity);
    }
}
