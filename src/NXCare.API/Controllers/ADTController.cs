using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NXCare.Domain.DTO;
using NXCare.Domain.Enums;
using NXCare.Domain.Interfaces.Services;

namespace NXCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ADTController : ControllerBase
    {
        private readonly IPatientCreationService patientCreationService;

        public ADTController(IPatientCreationService patientCreationService)
        {
            this.patientCreationService = patientCreationService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Admission(Patient patient)
        {
            try
            {
                var (patientCreationResults, publicId) = await patientCreationService.AddOrUpdatePatientAsync(patient, "TEST SOURCE").ConfigureAwait(false);

                if (patientCreationResults == PatientCreationResults.Error)
                {
                    throw new Exception();
                }

                patient.Id = publicId;

                return patientCreationResults == PatientCreationResults.Created ? Created(string.Empty, patient) : StatusCode(StatusCodes.Status200OK, patient);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError , "bidon");
            }
        }
    }
}
