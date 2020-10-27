using NXCare.Domain.Interfaces.Entities;

namespace NXCare.Domain.Entities.Base
{
    /// <summary>
    /// Base entity representing a table in the database.
    /// </summary>
    public abstract class AbstractBaseEntity : IBaseEntity
    {
    }

    /// <summary>
    /// Base entity with generic identifier representing a table in the database.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key/id, E.g. int or Guid.</typeparam>
    public abstract class AbstractBaseEntity<TKey> : AbstractBaseEntity, IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
