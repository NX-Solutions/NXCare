using System.Threading.Tasks;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.Base;

namespace NXCare.Domain.Interfaces.Repositories.NXCare
{
    public interface ICountryRepository : IBaseRepository<Country, int>
    {
        /// <summary>
        /// Returns a country by its alpha 2 code. if the <see cref="alpha2Code"/> is malformed or if no country was found then the default country is returned
        /// </summary>
        /// <param name="alpha2Code">The country's alpha 2 code to get</param>
        /// <returns>country with <see cref="alpha2Code"/> or default country is not found </returns>
        Task<Country> GetByIdAlpha2CodeAsync(string alpha2Code);
    }
}