using System;
using System.Collections.Generic;

namespace NXCare.Domain.DTO
{
    public class Patient : Person
    {
        public string ExternalId { get; set; }
    }
}
