using System;
using System.Threading.Tasks;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.Base;

namespace NXCare.Domain.Interfaces.Repositories.NXCare
{
    public interface IPatientRepository : IPublicBaseRepository<Patient,int, Guid, string>
    {
        Task<Patient> GetByIdAsync(int id, bool includeAllRelationships = false);
    }
}