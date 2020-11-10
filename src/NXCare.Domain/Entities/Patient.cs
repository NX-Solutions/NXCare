﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace NXCare.Domain.Entities
{
    public partial class Patient
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public string NationalId { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? NationalityId { get; set; }
        public int? LanguageId { get; set; }
        public int? Sex { get; set; }
        public string ExternalId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Language Language { get; set; }
        public virtual Country Nationality { get; set; }
        public virtual PatientAddress PatientAddress { get; set; }
    }
}