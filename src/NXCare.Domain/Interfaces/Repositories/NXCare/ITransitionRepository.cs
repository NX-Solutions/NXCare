using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.Base;

namespace NXCare.Domain.Interfaces.Repositories.NXCare
{
    public interface ITransitionRepository : IBaseRepository<Transition, int>
    {
    }
}