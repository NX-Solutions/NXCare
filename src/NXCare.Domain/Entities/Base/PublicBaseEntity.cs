using NXCare.Domain.Interfaces.Entities;

namespace NXCare.Domain.Entities.Base
{
    public class PublicBaseEntity<TKey, TPublicKey, TExternalId> : BaseEntity<TKey>, IPublicBaseEntity<TKey, TPublicKey, TExternalId>
    {
        public TPublicKey PublicId { get; set; }

        public TExternalId ExternalId { get; set; }
    }
}
