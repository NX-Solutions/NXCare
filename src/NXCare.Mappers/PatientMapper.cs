using System.Collections.Generic;
using System.Threading.Tasks;
using NXCare.Domain.DTO;
using NXCare.Domain.Interfaces.Mappers;
using NXCare.Domain.Interfaces.Repositories.NXCare;
using Patient = NXCare.Domain.Entities.Patient;

namespace NXCare.Mappers
{
    public class PatientMapper : IPatientMapper
    {
        private readonly IAddressMapper addressMapper;
        private readonly ILanguageMapper languageMapper;
        private readonly IPatientRepository patientRepository;
        private readonly ICountryRepository countryRepository;
        private readonly ILanguageRepository languageRepository;

        public PatientMapper(IAddressMapper addressMapper, ILanguageMapper languageMapper,  ICountryRepository countryRepository, ILanguageRepository languageRepository, IPatientRepository patientRepository)
        {
            this.addressMapper      = addressMapper;
            this.languageMapper     = languageMapper;
            this.patientRepository  = patientRepository;
            this.countryRepository  = countryRepository;
            this.languageRepository = languageRepository;
        }

        public async Task<(Patient Patient, bool IsNew)> ToEntityAsync(Domain.DTO.Patient patient)
        {
            if (patient == null) return (null, false);

            var existingPatient = await patientRepository.GetByExternalIdAsync(patient.ExternalId).ConfigureAwait(false);

            var language    = await languageRepository.GetByAlpha2CodeAsync(patient.Language?.Alpha2Code).ConfigureAwait(false);
            var nationality = await countryRepository.GetByIdAlpha2CodeAsync(patient.Nationality?.Alpha2Code).ConfigureAwait(false);

            var newPatient = new Patient
            {
                BirthDate     = patient.Birthdate,
                ExternalId    = patient.ExternalId,
                FirstName     = patient.FirstName,
                Language      = language,
                LanguageId    = language?.Id,
                LastName      = patient.LastName,
                Nationality   = nationality,
                NationalityId = nationality?.Id,
                MiddleName    = patient.MiddleName,
                Sex           = patient.Sex,
                NationalId    = patient.NationalId,
            };

            var isNew = existingPatient == null;
            if (!isNew)
            {
                newPatient.Id       = existingPatient.Id;
                newPatient.PublicId = existingPatient.PublicId;
            }

            return (newPatient, isNew);
        }

        public Domain.DTO.Patient ToDTO(Patient patient)
        {
            if (patient == null) return null;

            return new Domain.DTO.Patient
            {
                Id          = patient.PublicId,
                Nationality = patient.Nationality == null
                    ? null
                    : new Country
                    {
                        Id          = patient.Nationality?.Id ?? 0,
                        Alpha2Code  = patient.Nationality.Alpha2Code,
                        Alpha3Code  = patient.Nationality.Alpha3Code,
                        Name        = patient.Nationality.NameTranslationKey,
                        NumericCode = patient.Nationality.NumericCode
                    },
                Addresses  = new List<Address> {addressMapper.ToDTO(patient.PatientAddress?.Address)},
                ExternalId = patient.ExternalId,
                NationalId = patient.NationalId,
                Birthdate  = patient.BirthDate,
                FirstName  = patient.FirstName,
                LastName   = patient.LastName,
                MiddleName = patient.MiddleName,
                Sex        = patient.Sex ?? -1,
                Language   = languageMapper.ToDTO(patient.Language)
            };
        }
    }
}