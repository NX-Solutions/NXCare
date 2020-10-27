using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Data.Repositories.NXCare
{
    public class CountryRepository : BaseRepository<Country, int>, ICountryRepository
    {
        /// <inheritdoc />
        public CountryRepository(NXCareContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public Task<Country> GetByIdAlpha2CodeAsync(string alpha2Code)
        {
            return Set.FirstOrDefaultAsync(c => c.Alpha2Code == alpha2Code);
        }
    }
}