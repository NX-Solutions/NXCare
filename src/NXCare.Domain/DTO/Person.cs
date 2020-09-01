using System;
using System.Collections.Generic;

namespace NXCare.Domain.DTO
{
    public class Person
    {
        public Guid Id { get; set; }
        public string NationalId { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Firstname { get; set; }
        public DateTime Birthdate { get; set; }
        public Country Nationality { get; set; }
        public Language Language { get; set; }
        public int Sex { get; set; }
        public List<Address> Addresses { get; set; }
    }
}