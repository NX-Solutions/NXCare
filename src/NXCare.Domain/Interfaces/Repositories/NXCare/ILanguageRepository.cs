using System.Threading.Tasks;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.Base;

namespace NXCare.Domain.Interfaces.Repositories.NXCare
{
    public interface ILanguageRepository : IBaseRepository<Language, int>
    {
        Task<Language> GetByAlpha2CodeAsync(string alpha2Code);
    }
}