﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace NXCare.Domain.Entities
{
    public partial class PatientAddress
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AddressId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Address Address { get; set; }
        public virtual Patient Patient { get; set; }
    }
}