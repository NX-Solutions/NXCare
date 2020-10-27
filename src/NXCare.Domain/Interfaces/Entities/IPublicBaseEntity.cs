namespace NXCare.Domain.Interfaces.Entities
{
    public interface IPublicBaseEntity<TKey, TPublicKey, TExternalId> : INonTypedPublicBaseEntity, IBaseEntityWithDates<TKey>
    {
        TPublicKey PublicId { get; set; }

        TExternalId ExternalId { get; set; }
    }

    public interface INonTypedPublicBaseEntity
    {
    }
}