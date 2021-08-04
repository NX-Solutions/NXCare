using System;
using System.Threading.Tasks;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.Base;

namespace NXCare.Domain.Interfaces.Repositories.NXCare
{
    public interface IPatientRepository : IBaseRepository<Patient, int>
    {
        /// <summary>
        /// Deletes a patient by its public id.
        /// The operation sets the DeletedOn property to UTCNow
        /// </summary>
        /// <param name="publicId">The patient's public id</param>
        /// <returns>true if the deletion was successful, false otherwise</returns>
        Task<Patient> DeleteAsync(Guid publicId);

        /// <summary>
        /// Deletes a patient by its external id.
        /// The operation sets the DeletedOn property to UTCNow
        /// </summary>
        /// <param name="externalId">The patient's external id</param>
        /// <returns>true if the deletion was successful, false otherwise</returns>
        Task<Patient> DeleteAsync(string externalId);

        Task<Patient> GetByExternalIdAsync(string externalId);

        Task<Patient> GetByPublicIdAsync(Guid id);
    }
}