using System.Collections.Generic;
using System.Threading.Tasks;
using NXCare.Domain.DTO;

namespace NXCare.Domain.Interfaces.Mappers
{
    public interface IAddressMapper
    {
        Task<Domain.Entities.Address> ToEntityAsync(DTO.Address address);
        Address ToDTO(Domain.Entities.Address patientAddressAddress);
    }
}
