using System.Threading.Tasks;
using NXCare.Domain.Entities;

namespace NXCare.Domain.Interfaces.Mappers
{
    public interface IPatientMapper
    {
        /// <summary>
        /// Maps patient data transfer object to its entity.
        /// If the patient is already present in the database than the patient entity is returned with all fields updated otherwise a new instance is created
        /// </summary>
        /// <param name="patient">Patient data sent by ADT</param>
        /// <returns>A entity with data of <see cref="patient"/></returns>
        Task<(Patient Patient, bool IsNew)> ToEntityAsync(DTO.Patient patient);
    }
}