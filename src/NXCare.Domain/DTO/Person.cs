using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NXCare.Domain.DTO
{
    public class Person
    {
        public Guid Id { get; set; }
        public string NationalId { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public DateTime? Birthdate { get; set; }
        public Country Nationality { get; set; }
        public Language Language { get; set; }
        public int Sex { get; set; }
        public List<Address> Addresses { get; set; }
    }
}