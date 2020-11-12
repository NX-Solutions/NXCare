using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Data.Repositories.NXCare
{
    public class PatientRepository : PublicBaseRepository<Patient, int, Guid, string>, IPatientRepository
    {
        private readonly NXCareContext context;

        /// <inheritdoc />
        public PatientRepository(NXCareContext context) : base(context)
        {
            this.context = context;
        }

        public Task<Patient> GetByIdAsync(int id, bool includeAllRelationships = false)
        {
            return includeAllRelationships == false
                ? base.GetByIdAsync(id)
                : Set.Include(patient => patient.Language)
                    .Include(patient => patient.PatientAddress.Address).ThenInclude(patient => patient.PatientAddress.Address.Country)
                    .Include(patient => patient.Nationality)
                    .FirstOrDefaultAsync(patient => patient.Id == id);
        }

        public async Task<Address> GetPatientAddressByPatientId(int patientId)
        {
            var patientAddress = await context.PatientAddress.Include(pa => pa.Address).FirstOrDefaultAsync(pa => pa.PatientId == patientId);
            return patientAddress?.Address;
        }
    }
}