using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Data.Repositories.NXCare
{
    public class TransitionRepository : BaseRepository<Transition, int>, ITransitionRepository
    {
        /// <inheritdoc />
        public TransitionRepository(NXCareContext context) : base(context)
        {
        }
    }
}