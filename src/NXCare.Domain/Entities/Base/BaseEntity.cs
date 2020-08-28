using NXCare.Domain.Interfaces.Entities;

namespace NXCare.Domain.Entities.Base
{
    /// <summary>
    /// Base entity representing a table in the database.
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
    }

    /// <summary>
    /// Base entity with generic identifier representing a table in the database.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key/id, E.g. int or Guid.</typeparam>
    public abstract class BaseEntity<TKey> : BaseEntity, IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}