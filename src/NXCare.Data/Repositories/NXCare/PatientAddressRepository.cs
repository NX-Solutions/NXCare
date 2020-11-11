using Microsoft.EntityFrameworkCore;
using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NXCare.Data.Repositories.NXCare
{
    public class PatientAddressRepository : BaseRepository<PatientAddress, int>, IPatientAddressRepository
    {

        public PatientAddressRepository(NXCareContext context) : base(context)
        {
        }

        public IQueryable<PatientAddress> Query() => Set.Include(patientAddress => patientAddress.Patient).Include(patientAddress => patientAddress.Address);

        public Task<PatientAddress> GetPatientAndAddressByPatientExternalId(string externalId)
        {
            return Query().FirstOrDefaultAsync(patientAddress => patientAddress.Patient.ExternalId == externalId);
        }

        public Task<PatientAddress> GetPatientAndAddressByPatientId(int patientId)
        {
            return Query().FirstOrDefaultAsync(patientAddress => patientAddress.PatientId == patientId);
        }

        public Task<PatientAddress> GetPatientAndAddressByPatientPublicId(Guid publicId)
        {
            return Query().FirstOrDefaultAsync(patientAddress => patientAddress.Patient.PublicId == publicId);
        }
    }
}
