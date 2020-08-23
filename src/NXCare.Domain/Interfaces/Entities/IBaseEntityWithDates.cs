using System;

namespace NXCare.Domain.Interfaces.Entities
{

    /// <summary>
    /// Base entity interface with generic identifier representing a table in the database and date fields (<see cref="IBaseEntityWithDates.CreatedOn"/>, <see cref="IBaseEntityWithDates.ModifiedOn"/>, <see cref="IBaseEntityWithDates.DeletedOn"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key/id, E.g. int or Guid.</typeparam>
    public interface IBaseEntityWithDates<TKey> : IBaseEntityWithDates, IBaseEntity<TKey>
    {
    }

    public interface IBaseEntityWithDates
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
        DateTime? DeletedOn { get; set; }
    }
}