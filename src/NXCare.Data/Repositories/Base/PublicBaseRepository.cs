using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXCare.Domain.Entities.Base;
using NXCare.Domain.Interfaces.Entities;
using NXCare.Domain.Interfaces.Repositories;

namespace NXCare.Data.Repositories.Base
{
    public class PublicBaseRepository<TEntity, TKey, TPublicKey, TExternalKey> : BaseRepository<TEntity, TKey>, IPublicBaseRepository<TEntity, TKey, TPublicKey, TExternalKey>
        where TEntity : AbstractBaseEntity, IPublicBaseEntity<TKey, TPublicKey, TExternalKey>
    {
        /// <inheritdoc />
        public PublicBaseRepository(DbContext context) : base(context)
        {
        }

        public virtual Task<TEntity> GetByPublicIdAsync(TPublicKey publicKey)
        {
            return Set.FirstOrDefaultAsync(entity => entity.PublicId.Equals(publicKey));
        }

        public virtual Task<TEntity> GetByExternalIdAsync(TExternalKey externalKey)
        {
            return Set.FirstOrDefaultAsync(entity => entity.ExternalId.Equals(externalKey));
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> DeleteAsync(TPublicKey publicId)
        {
            var patient = await GetByPublicIdAsync(publicId).ConfigureAwait(false);
            return patient == null ? null : SoftDelete(patient);
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> DeleteAsync(TExternalKey externalId)
        {
            var patient = await GetByExternalIdAsync(externalId).ConfigureAwait(false);
            return patient == null ? null : SoftDelete(patient);
        }
    }
}