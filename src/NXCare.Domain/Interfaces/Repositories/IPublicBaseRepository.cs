using System.Threading.Tasks;
using NXCare.Domain.Entities.Base;
using NXCare.Domain.Interfaces.Entities;
using NXCare.Domain.Interfaces.Repositories.Base;

namespace NXCare.Domain.Interfaces.Repositories
{
    public interface IPublicBaseRepository<TEntity, TKey, TPublicKey, TExternalKey> : IBaseRepository<TEntity, TKey>  where TEntity : AbstractBaseEntity, IPublicBaseEntity<TKey, TPublicKey, TExternalKey>
    {
        Task<TEntity> GetByPublicIdAsync(TPublicKey publicKey);

        Task<TEntity> GetByExternalIdAsync(TExternalKey externalKey);

        /// <summary>
        /// Deletes an entity by its public id.
        /// The operation sets the DeletedOn property to UTCNow
        /// </summary>
        /// <param name="publicId">The entity's public id</param>
        /// <returns>true if the deletion was successful, false otherwise</returns>
        Task<TEntity> DeleteAsync(TPublicKey publicId);

        /// <summary>
        /// Deletes an entity by its external id.
        /// The operation sets the DeletedOn property to UTCNow
        /// </summary>
        /// <param name="externalId">The entity's external id</param>
        /// <returns>true if the deletion was successful, false otherwise</returns>
        Task<TEntity> DeleteAsync(TExternalKey externalId);
    }
}