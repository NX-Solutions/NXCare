using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.Base;
using System;
using System.Threading.Tasks;

namespace NXCare.Domain.Interfaces.Repositories.NXCare
{
    public interface IPatientAddressRepository : IBaseRepository<PatientAddress, int>
    {
        Task<PatientAddress> GetPatientAndAddressByPatientId(int patientId);

        Task<PatientAddress> GetPatientAndAddressByPatientExternalId(string externalId);

        Task<PatientAddress> GetPatientAndAddressByPatientPublicId(Guid publicId);
    }
}