using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NXCare.Domain.Interfaces.Entities;

namespace NXCare.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : IBaseEntity<TKey>
    {
        /// <summary>
        /// Get entity by primary key.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(TKey id);

        /// <summary>
        /// Get entity by primary key and expose the possibility to specify property navigation inclusion
        /// </summary>
        /// <param name="id">id of the entity to look for</param>
        /// <param name="includes">navigation extra properties inclusion</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Returns a list of entities filtered, order and including entities children
        /// </summary>
        /// <param name="filterCriteria">optional where statement to filter data</param>
        /// <param name="orderBy">optional order by statement</param>
        /// <param name="includes">extras properties to include</param>
        /// <returns></returns>
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filterCriteria = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Add entity to the context.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Add(TEntity entity);

        ///<summary>
        /// Add entities to the context.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Mark an entity as updated.
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Mark entities as updated.
        /// </summary>
        /// <param name="entities"></param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Add an entity to the context or update it if its id is not the default value type
        /// </summary>
        /// <param name="entity">the entity to add or update</param>
        void AddOrUpdate(TEntity entity);

        /// <summary>
        /// Delete an entity from the context.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>the deleted entity</returns>
        TEntity Delete(TEntity entity);

        /// <summary>
        /// Delete an collection of entities from the context.
        /// </summary>
        /// <param name="entities">The entities to delete.</param>
        void DeleteRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Delete an entity by its primary key.
        /// </summary>
        /// <param name="id">The primary key of the entity.</param>
        /// <returns>the deleted entity</returns>
        Task<TEntity> DeleteByIdAsync(TKey id);

        /// <summary>
        /// Soft delete a base entity by setting deletedOn date to UtcNow
        /// </summary>
        /// <param name="id">the id of the entity to soft delete</param>
        /// <returns></returns>
        Task<TEntity> SoftDeleteByIdAsync(TKey id);

        /// <summary>
        /// Soft delete the given entity
        /// </summary>
        /// <param name="entity">the entity to soft delete by setting DeletedOn property to UtcNow</param>
        /// <returns></returns>
        TEntity SoftDelete(TEntity entity);

        Task<bool> ExistsAsync(TKey id);
    }
}