﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXCare.Domain.Entities;
using NXCare.Domain.Entities.Base;
using NXCare.Domain.Interfaces.Entities;
using NXCare.Domain.Interfaces.Repositories.Base;

namespace NXCare.Data.Repositories.Base
{
    /// <summary>
    /// Generic repository targeting Entity Framework.
    /// </summary>
    /// <typeparam name="TEntity">the type of the repository's entity</typeparam>
    /// <typeparam name="TKey">the type of the TEntity primary key</typeparam>
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : AbstractBaseEntity, IBaseEntity<TKey>
    {
        protected DbSet<TEntity> Set;
        private readonly DbContext context;

        public BaseRepository(DbContext context)
        {
            Set = context.Set<TEntity>();
            this.context = context;
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await Set.FindAsync(id).ConfigureAwait(false);
        }

        public virtual Task<TEntity> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Set;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.SingleOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return Set.ToListAsync();
        }

        public virtual Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filterCriteria = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Set;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filterCriteria != null)
                query = query.Where(filterCriteria);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToListAsync();
        }

        public virtual TEntity Add(TEntity entity)
        {
            return Set.Add(entity)?.Entity;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Set.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            var existingEntity = Set.Local.FirstOrDefault(localEntity => localEntity.Id.Equals(entity.Id));
            if (existingEntity != null && !ReferenceEquals(existingEntity, entity))
            {
                context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                Set.Update(entity);
            }
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public virtual void AddOrUpdate(TEntity entity)
        {
            if (entity.Id.Equals(default(TKey)))
            {
                Add(entity);
            }
            else
            {
                Update(entity);
            }
        }

        public virtual TEntity Delete(TEntity entity)
        {
            return Set.Remove(entity).Entity;
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            Set.RemoveRange(entities);
        }

        public virtual TEntity SoftDelete(TEntity entity)
        {
            if (entity is IBaseEntityWithDates<TKey> baseEntityWithDates && !baseEntityWithDates.DeletedOn.HasValue)
            {
                baseEntityWithDates.DeletedOn = DateTime.UtcNow;
            }

            return entity;
        }

        public virtual async Task<TEntity> DeleteByIdAsync(TKey id)
        {
            var entity = await GetByIdAsync(id).ConfigureAwait(false);
            return Delete(entity);
        }

        public virtual async Task<TEntity> SoftDeleteByIdAsync(TKey id)
        {
            var entity = await GetByIdAsync(id).ConfigureAwait(false);
            return SoftDelete(entity);
        }

        public virtual async Task<bool> ExistsAsync(TKey id)
        {
            return await Set.FindAsync(id).ConfigureAwait(false) != null;
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => context.SaveChangesAsync(cancellationToken);
    }
}