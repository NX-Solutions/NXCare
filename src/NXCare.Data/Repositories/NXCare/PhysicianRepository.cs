using System;
using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Data.Repositories.NXCare
{
    public class PhysicianRepository : PublicBaseRepository<Physician, int, Guid, string>, IPhysicianRepository
    {
        /// <inheritdoc />
        public PhysicianRepository(NXCareContext context) : base(context)
        {
        }
    }
}