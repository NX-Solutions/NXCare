using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXCare.Domain.DTO
{
    public class Visit
    {
        public Guid Id { get; set; }
        public string ExternalId { get; set; }
        public int AdmissionType { get; set; }
        public DateTime AdmitDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public List<Transition> Transitions { get; set; }
        public Location CurrentLocation { get; set; }
        public Location PriorLocation { get; set; }
        public Physician AttendingPhysician { get; set; }
        public Physician ReferringPhysician { get; set; }
        public Physician ConsultingPhysician { get; set; }
        public Physician AdmittingPhysician { get; set; }
    }
}
