using NXCare.Domain.DTO;

namespace NXCare.Domain.Interfaces.Mappers
{
    public interface ICountryMapper
    {
        Country ToDTO(Domain.Entities.Country country);
    }
}