using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Mappers;
using NXCare.Domain.Interfaces.Repositories.NXCare;
using Address = NXCare.Domain.DTO.Address;
using Country = NXCare.Domain.DTO.Country;
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

        public async Task<(Patient Patient, bool IsNew)> ToNewOrUpdatedEntityAsync(Domain.DTO.Patient patient)
        {
            if (patient == null) return (null, false);

            var existingPatient = await patientRepository.GetByExternalIdAsync(patient.ExternalId).ConfigureAwait(false);
            var language        = await languageRepository.GetByAlpha2CodeAsync(patient.Language?.Alpha2Code).ConfigureAwait(false);
            var nationality     = await countryRepository.GetByIdAlpha2CodeAsync(patient.Nationality?.Alpha2Code).ConfigureAwait(false);

            var isNew = existingPatient == null;

            if (existingPatient == null)
            {
                existingPatient = await CreateNewPatient(patient, language, nationality);
            }
            else
            {
                await SetNewValues(existingPatient, patient, nationality?.Id, language?.Id);
            }

            return (existingPatient, isNew);
        }

        private async Task<Patient> CreateNewPatient(Domain.DTO.Patient patient, Language language, Domain.Entities.Country nationality)
        {
            var existingPatient = new Patient
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
                NationalId    = patient.NationalId
            };

            if (patient.Addresses != null && patient.Addresses.Count > 0)
            {
                var addressDTO                 = patient.Addresses.FirstOrDefault();
                var country                    = addressDTO.Country != null ? await countryRepository.GetByIdAlpha2CodeAsync(addressDTO.Country?.Alpha2Code) : null;
                existingPatient.PatientAddress = new PatientAddress()
                {
                    Address = new Domain.Entities.Address()
                    {
                        City       = addressDTO.City,
                        CountryId  = country?.Id,
                        Number     = addressDTO.Number,
                        Street     = addressDTO.Street,
                        PostalCode = addressDTO.PostalCode
                    }
                };
            }

            return existingPatient;
        }

        private async Task SetNewValues(Patient patient, Domain.DTO.Patient patientDTO, int? nationalityId, int? languageId)
        {
            patient.BirthDate     = patientDTO.Birthdate;
            patient.ExternalId    = patientDTO.ExternalId;
            patient.FirstName     = patientDTO.FirstName;
            patient.LanguageId    = languageId;
            patient.LastName      = patient.LastName;
            patient.NationalityId = nationalityId;
            patient.MiddleName    = patientDTO.MiddleName;
            patient.Sex           = patientDTO.Sex;
            patient.NationalId    = patientDTO.NationalId;

            var address    = await patientRepository.GetPatientAddressByPatientId(patient.Id) ?? new Domain.Entities.Address();
            var addressDTO = patientDTO.Addresses?.FirstOrDefault();

            if (addressDTO != null)
            {
                address.Street     = addressDTO.Street;
                address.City       = addressDTO.City;
                address.CountryId  = addressDTO.Country != null ? (await countryRepository.GetByIdAlpha2CodeAsync(addressDTO.Country?.Alpha2Code))?.Id : null;
                address.Number     = addressDTO.Number;
                address.Street     = addressDTO.Street;
                address.PostalCode = addressDTO.PostalCode;

                if (address.Id == default)
                {
                    patient.PatientAddress = new PatientAddress() {Address = address};
                }
            }
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
                        Id          = patient.Nationality.Id,
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