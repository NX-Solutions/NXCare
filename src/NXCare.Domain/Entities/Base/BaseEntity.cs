using System;
using NXCare.Domain.Interfaces.Entities;

namespace NXCare.Domain.Entities.Base
{
    /// <summary>
    /// Base entity with generic identifier representing a table in the database and date fields (<see cref="CreatedOn"/>, <see cref="ModifiedOn"/>, <see cref="DeletedOn"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key/id, E.g. int or Guid.</typeparam>
    public abstract class BaseEntity<TKey> : AbstractBaseEntity<TKey>, IBaseEntityWithDates<TKey>
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}