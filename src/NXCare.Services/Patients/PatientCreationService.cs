﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NXCare.Domain.DTO;
using NXCare.Domain.Enums;
using NXCare.Domain.Extensions;
using NXCare.Domain.Interfaces.Mappers;
using NXCare.Domain.Interfaces.Repositories.NXCare;
using NXCare.Domain.Interfaces.Services;

namespace NXCare.Services.Patients
{
    public class PatientCreationService : IPatientCreationService
    {
        private readonly ILogger<PatientCreationService> logger;
        private readonly IPatientRepository patientRepository;
        private readonly IPatientMapper patientMapper;

        public PatientCreationService(ILogger<PatientCreationService> logger, IPatientRepository patientRepository, IPatientMapper patientMapper)
        {
            this.logger                   = logger;
            this.patientRepository        = patientRepository;
            this.patientMapper            = patientMapper;
        }

        public async Task<(PatientCreationResults PatientCreationResults, Patient Patient)> AddOrUpdatePatientAsync(Patient patient, string source)
        {
            try
            {
                LogReceivedPatient(patient, source);
                var (patientEntity, isNew) = await AddOrUpdateAsync(patient).ConfigureAwait(false);
                LogAddedOrUpdatedPatient(patient, source, isNew);
                return (isNew ? PatientCreationResults.Created : PatientCreationResults.Updated, patientMapper.ToDTO(await patientRepository.GetByIdAsync(patientEntity.Id, true)));
            }
            catch (Exception ex)
            {
                logger.LogError((int) LogEventIds.PatientCreation, ex, $"{nameof(AddOrUpdatePatientAsync)}: Data received: {patient.ToJson()}");
                return (PatientCreationResults.Error, null);
            }
        }

        private async Task<(Domain.Entities.Patient Patient, bool IsNew)> AddOrUpdateAsync(Patient patient)
        {
            var mappedResults = await patientMapper.ToNewOrUpdatedEntityAsync(patient).ConfigureAwait(false);

            if (mappedResults.IsNew)
            {
                patientRepository.Add(mappedResults.Patient);
            }
            else
            {
                patientRepository.Update(mappedResults.Patient);
            }

            await patientRepository.SaveChangesAsync().ConfigureAwait(false);

            return (mappedResults.Patient, mappedResults.IsNew);
        }

        public async Task<PatientDeletionResult> DeletePatientByIdAsync(Guid id)
        {
            try
            {
                var deletedPatient    = await patientRepository.DeleteAsync(id).ConfigureAwait(false);
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
            logger.LogInformation((int) LogEventIds.PatientCreation, $"A new patient with external id `{patientDTO.ExternalId}` - {patientDTO.FirstName} {patientDTO.LastName} received from {source}");
        }

        private void LogAddedOrUpdatedPatient(Patient patientDTO, string source, bool isNew)
        {
            logger.LogInformation((int) LogEventIds.PatientCreation, $"Patient sent by {source} with external id `{patientDTO.ExternalId} - {patientDTO.FirstName} {patientDTO.LastName} was successfully {(isNew ? "added" : "updated")}");
        }
    }
}