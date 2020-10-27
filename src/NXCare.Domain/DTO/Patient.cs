using System.ComponentModel.DataAnnotations;

namespace NXCare.Domain.DTO
{
    public class Patient : Person
    {
        public string ExternalId { get; set; }
    }
}
