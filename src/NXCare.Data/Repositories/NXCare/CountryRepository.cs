using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Data.Repositories.NXCare
{
    public class CountryRepository : BaseRepository<Country,int>, ICountryRepository
    {
        /// <inheritdoc />
        public CountryRepository(NXCareContext context) : base(context)
        {
        }
    }
}