using Empresa.Proyecto.Core.Entities;
using Empresa.Proyecto.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Proyecto.Infra.Data
{
    /// <summary>
    /// Repositorio base de Entity Framework para las distintas entidades del portal
    /// </summary>
    /// <typeparam name="T">Entidad T de Core</typeparam>
    /// <typeparam name="Y">Tipo de DBContext, para Dependiency Injection</typeparam>
    public class EFRepository<T>: IAsyncRepository<T> where T:BaseEntity
    {
        private readonly MyProjectContext _dbContext;
        /// <summary>
        /// Inicializa el repositorio con un contexto de Base de Datos
        /// </summary>
        /// <param name="dbContext">DBContext con el cual interactuara el Repostiorio</param>
        public EFRepository(MyProjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Obtiene un elemento por su id
        /// </summary>
        /// <param name="id">Id del elemento</param>
        /// <returns>Entidad de tipo <c>T</c></returns>
        public virtual async Task<T?> GetbyIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Regresa un listado de todas las entidades
        /// </summary>
        /// <returns>Coleccion de entidades</returns>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Agrega una Entidad al repositorio
        /// </summary>
        /// <param name="entity">Entidad de tipo <c>T</c> a agregar</param>
        /// <returns>Entidad actualizada, con su Id generado</returns>
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Actualiza los valores de una entidad en el repositorio
        /// </summary>
        /// <param name="entity">Entidad <c>T</c> a actualizar</param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Elimina una entidad del repositorio
        /// </summary>
        /// <param name="entity">Entidad <c>T</c> a eliminar</param>
        /// <returns></returns>
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Busca una entidad segun una especificacion
        /// </summary>
        /// <param name="spec">Reglas definidas en la especificacion para encontrar un registro</param>
        /// <returns>Entidad encontrada, o nulo</returns>
        public async Task<T?> GetAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Busca un conjunto de entidades, segun una especificacion
        /// </summary>
        /// <param name="spec">Reglas definidas en la especificacion para encontrar multiples entidades del repositorio</param>
        /// <returns>Coleccion de entidades o nulo si no hubo coincidencias</returns>
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private protected IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

    }
}
