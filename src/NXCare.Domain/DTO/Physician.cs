using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXCare.Domain.DTO
{
    public class Physician : Person
    {
        public string MedicalLicenseId { get; set; }
        public string Speciality { get; set; }
    }
}
