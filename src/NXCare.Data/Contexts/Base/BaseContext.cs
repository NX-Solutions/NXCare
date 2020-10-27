using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NXCare.Domain.Exceptions;
using NXCare.Domain.Interfaces.Entities;

namespace NXCare.Data.Contexts.Base
{

    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        /// <inheritdoc />
        protected BaseContext()
        {
        }

        /// <inheritdoc />
        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        public BaseContext(DbContextOptions<TContext> options)
            : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            int savedNumber;

            try
            {
                UpdateDates();
                HandlePublicEntities();
                savedNumber = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                HandleSaveChangesException(exception);

                throw;
            }

            return savedNumber;
        }

        public void UpdateDates()
        {
            var addedEntities = ChangeTracker.Entries<IBaseEntityWithDates>().Where(entry => entry.State == EntityState.Added);
            foreach (var entityEntry in addedEntities)
            {
                entityEntry.Entity.CreatedOn = DateTime.UtcNow;
            }

            var entities = ChangeTracker.Entries<IBaseEntityWithDates>().Where(entry => entry.State == EntityState.Modified);
            foreach (var entityEntry in entities)
            {
                entityEntry.Entity.ModifiedOn = DateTime.UtcNow;
                entityEntry.Property(nameof(IBaseEntityWithDates.CreatedOn)).IsModified = false;
            }
        }

        public void HandlePublicEntities()
        {
            var publicEntityEntries = ChangeTracker.Entries<INonTypedPublicBaseEntity>().Where(entry => entry.State == EntityState.Modified); ;
            foreach (var entityEntry in publicEntityEntries)
            {
                entityEntry.Property(nameof(IPublicBaseEntity<object,object,object>.PublicId)).IsModified = false;
                entityEntry.Property(nameof(IPublicBaseEntity<object,object,object>.ExternalId)).IsModified = false;
            }
        }

        private void HandleDbUpdateException(SqlException sqlException)
        {
            if (sqlException.Number == 2601 || sqlException.Number == 2627) throw new UniqueConstraintViolationException();
        }

        private void HandleSaveChangesException(Exception exception)
        {
            if (exception is DbUpdateException dbUpdateException && dbUpdateException.InnerException is SqlException sqlException)
            {
                HandleDbUpdateException(sqlException);
            }
        }
    }
}
