using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Data.Repositories.NXCare
{
    public class PatientRepository : PublicBaseRepository<Patient, int, Guid, string>, IPatientRepository
    {
        /// <inheritdoc />
        public PatientRepository(NXCareContext context) : base(context)
        {
        }
    }
}