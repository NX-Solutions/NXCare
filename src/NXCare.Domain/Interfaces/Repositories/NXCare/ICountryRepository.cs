using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.Base;

namespace NXCare.Domain.Interfaces.Repositories.NXCare
{
    public interface ICountryRepository : IBaseRepository<Country, int>
    {
    }
}