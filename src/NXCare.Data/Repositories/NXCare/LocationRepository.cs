using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Data.Repositories.NXCare
{
    public class LocationRepository : BaseRepository<Location, int>, ILocationRepository
    {
        /// <inheritdoc />
        public LocationRepository(NXCareContext context) : base(context)
        {
        }
    }
}