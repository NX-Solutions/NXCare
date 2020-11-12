﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXCare.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        Task AddOrUpdatePatientAddress(Guid patientId, Domain.DTO.Address address);
    }
}