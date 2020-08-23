namespace NXCare.Domain.Interfaces.Entities
{
    /// <summary>
    /// Base entity interface representing a table in the database.
    /// </summary>
    public interface IBaseEntity
    {
    }

    /// <summary>
    /// Base entity interface with generic identifier representing a table in the database.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key/id, E.g. int or Guid.</typeparam>
    public interface IBaseEntity<TKey> : IBaseEntity
    {
        public TKey Id { get; set; }
    }
}