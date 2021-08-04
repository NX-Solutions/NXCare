using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NXCare.Domain.DTO;
using NXCare.Domain.Enums;
using NXCare.Domain.Extensions;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Services.Patients
{
    public class PatientCreationService
    {
        private readonly ILogger<PatientCreationService> logger;
        private readonly IPatientRepository patientRepository;

        public PatientCreationService(ILogger<PatientCreationService> logger, IPatientRepository patientRepository)
        {
            this.logger            = logger;
            this.patientRepository = patientRepository;
        }

        //TODO patient's external id should be unique ?

        public async Task<PatientCreationResults> AddOrUpdatePatientAsync(Patient patientDTO, string source)
        {
            try
            {
                LogReceivedPatient(patientDTO, source);
                var existingPatient = await patientRepository.GetByExternalIdAsync(patientDTO.ExternalId).ConfigureAwait(false);
                var patientEntity   = patientDTO.ToPatient();

                //TODO if existing, check potential null value for the new incoming patient and if yes fall back for those ones to the previous value ?
                if (existingPatient != null) patientEntity.Id = existingPatient.Id;
                patientRepository.AddOrUpdate(patientEntity);
                await patientRepository.SaveChangesAsync().ConfigureAwait(false);
                LogAddedOrUpdatedPatient(patientDTO, source);
                return PatientCreationResults.Success;
            }
            catch (Exception ex)
            {
                logger.LogError((int) LogEventIds.PatientCreation, ex, $"{nameof(AddOrUpdatePatientAsync)}: Data received: {patientDTO.ToJson()}");
                return PatientCreationResults.Error;
            }
        }

        public async Task<PatientDeletionResult> DeletePatientByIdAsync(Guid id)
        {
            try
            {
                var deletedPatient = await patientRepository.DeleteAsync(id).ConfigureAwait(false);
                return deletedPatient == null ? PatientDeletionResult.DoesNotExist : PatientDeletionResult.Success;
            }
            catch (Exception ex)
            {
                logger.LogError((int) LogEventIds.PatientDeletion, ex, $"{nameof(DeletePatientByIdAsync)}: an error occurred while deleting patient with public id {id}");
                return PatientDeletionResult.Error;
            }
        }

        //TODO log who did that
        public async Task<PatientDeletionResult> DeletePatientByExternalIdAsync(string externalId)
        {
            try
            {
                var deletedPatient = await patientRepository.DeleteAsync(externalId).ConfigureAwait(false);
                LogPatientExternalIdDeletion(deletedPatient, externalId);
                return deletedPatient == null ? PatientDeletionResult.DoesNotExist : PatientDeletionResult.Success;
            }
            catch (Exception ex)
            {
                logger.LogError((int) LogEventIds.PatientDeletion, ex, $"{nameof(DeletePatientByIdAsync)}: an error occurred while deleting patient with external id {externalId}");
                return PatientDeletionResult.Error;
            }
        }

        private void LogPatientExternalIdDeletion(Domain.Entities.Patient deletedPatient, string externalId)
        {
            if (deletedPatient == null)
            {
                logger.LogWarning((int) LogEventIds.PatientDeletion, $"Tried to delete patient with external id `{externalId}` but he/she doesn't exist");
            }
            else
            {
                logger.LogInformation((int) LogEventIds.PatientDeletion, $"Patient with external id `{externalId}` deleted with success");
            }
        }

        private void LogReceivedPatient(Patient patientDTO, string source)
        {
            logger.LogInformation((int) LogEventIds.PatientCreation, $"A new patient with external id `{patientDTO.ExternalId}` - {patientDTO.Firstname} {patientDTO.Lastname} received from {source}");
        }

        private void LogAddedOrUpdatedPatient(Patient patientDTO, string source)
        {
            logger.LogInformation((int) LogEventIds.PatientCreation, $"Patient sent by {source} with external id `{patientDTO.ExternalId} - {patientDTO.Firstname} {patientDTO.Lastname} was successfully added to the database ");
        }
    }

    public static class PatientMapper
    {
        public static Domain.Entities.Patient ToPatient(this Patient patientDTO)
        {
            return patientDTO == null
                ? null
                : new Domain.Entities.Patient()
                {
                    ExternalId    = patientDTO.ExternalId,
                    //LanguageId  = pati
                    BirthDate     = patientDTO.Birthdate,
                    FirstName     = patientDTO.Firstname,
                    LastName      = patientDTO.Firstname,
                    MiddleName    = patientDTO.Middlename,
                    NationalId    = patientDTO.NationalId,
                    Sex           = patientDTO.Sex,
                    NationalityId = patientDTO.Nationality.Id
                };
        }
    }
}