using System;
using System.Threading.Tasks;
using NXCare.Domain.DTO;
using NXCare.Domain.Enums;

namespace NXCare.Domain.Interfaces.Services
{
    public interface IPatientCreationService
    {
        Task<(PatientCreationResults PatientCreationResults, Patient Patient)> AddOrUpdatePatientAsync(Patient patient, string source);
    }
}