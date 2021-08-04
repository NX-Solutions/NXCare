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
    }
}