using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Data.Repositories.NXCare
{
    public class LanguageRepository : BaseRepository<Language,int>, ILanguageRepository
    {
        /// <inheritdoc />
        public LanguageRepository(NXCareContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public Task<Language> GetByAlpha2CodeAsync(string alpha2Code)
        {
            return Set.FirstOrDefaultAsync(l => l.Alpha2Code == alpha2Code);
        }
    }
}