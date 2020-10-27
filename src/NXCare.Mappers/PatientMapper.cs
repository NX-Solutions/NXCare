using System.Threading.Tasks;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Mappers;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Mappers
{
    public class PatientMapper : IPatientMapper
    {
        private readonly IPatientRepository patientRepository;
        private readonly ICountryRepository countryRepository;
        private readonly ILanguageRepository languageRepository;

        public PatientMapper(IPatientRepository patientRepository, ICountryRepository countryRepository, ILanguageRepository languageRepository)
        {
            this.patientRepository  = patientRepository;
            this.countryRepository  = countryRepository;
            this.languageRepository = languageRepository;
        }

        public async Task<(Patient Patient, bool IsNew)> ToEntityAsync(Domain.DTO.Patient patient)
        {
            var existingPatient = await patientRepository.GetByExternalIdAsync(patient.ExternalId).ConfigureAwait(false);

            var newPatient = new Patient
            {
                BirthDate   = patient.Birthdate,
                ExternalId  = patient.ExternalId,
                FirstName   = patient.FirstName,
                Language    = await languageRepository.GetByAlpha2CodeAsync(patient.Language?.Alpha2Code).ConfigureAwait(false),
                LastName    = patient.LastName,
                Nationality = await countryRepository.GetByIdAlpha2CodeAsync(patient.Nationality?.Alpha2Code).ConfigureAwait(false),
                MiddleName  = patient.MiddleName,
                Sex         = patient.Sex,
                NationalId  = patient.NationalId
            };

            var isNew = existingPatient == null;
            if (!isNew)
            {
                newPatient.Id       = existingPatient.Id;
                newPatient.PublicId = existingPatient.PublicId;
            }

            return (newPatient, isNew);
        }
    }
}