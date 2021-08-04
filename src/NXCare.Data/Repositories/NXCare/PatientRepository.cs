using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Data.Repositories.NXCare
{
    public class PatientRepository : BaseRepository<Patient, int>, IPatientRepository
    {
        /// <inheritdoc />
        public PatientRepository(NXCareContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public async Task<Patient> DeleteAsync(Guid publicId)
        {
            var patient = await GetByPublicIdAsync(publicId).ConfigureAwait(false);
            return patient == null ? null : SoftDelete(patient);
        }

        /// <inheritdoc />
        public async Task<Patient> DeleteAsync(string externalId)
        {
            var patient = await GetByExternalIdAsync(externalId).ConfigureAwait(false);
            return patient == null ? null : SoftDelete(patient);
        }

        /// <inheritdoc />
        public Task<Patient> GetByExternalIdAsync(string externalId)
        {
            return Set.FirstOrDefaultAsync(patient => patient.ExternalId == externalId);
        }

        /// <inheritdoc />
        public Task<Patient> GetByPublicIdAsync(Guid id)
        {
            return Set.FirstOrDefaultAsync(patient => patient.PublicId == id);
        }
    }
}