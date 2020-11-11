using NXCare.Domain.DTO;
using NXCare.Domain.Interfaces.Mappers;

namespace NXCare.Mappers
{
    public class CountryMapper : ICountryMapper
    {
        public Country ToDTO(Domain.Entities.Country country)
        {
            if (country == null) return null;

            return new Country
            {
                Alpha2Code  = country.Alpha2Code,
                Alpha3Code  = country.Alpha3Code,
                Id          = country.Id,
                NumericCode = country.NumericCode,
                Name        = country.NameTranslationKey
            };
        }
    }
}