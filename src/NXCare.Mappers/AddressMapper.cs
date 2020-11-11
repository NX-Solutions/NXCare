using System.Threading.Tasks;
using NXCare.Domain.Interfaces.Mappers;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Mappers
{
    public class AddressMapper : IAddressMapper
    {
        private readonly ICountryMapper countryMapper;
        private readonly ICountryRepository countryRepository;

        public AddressMapper(ICountryMapper countryMapper, ICountryRepository countryRepository)
        {
            this.countryMapper = countryMapper;
            this.countryRepository = countryRepository;
        }

        public async Task<Domain.Entities.Address> ToEntityAsync(Domain.DTO.Address address)
        {
            if (address == null) return null;

            var country = await countryRepository.GetByIdAlpha2CodeAsync(address.Country.Alpha2Code).ConfigureAwait(false);

            return new Domain.Entities.Address()
            {
                Street     = address.Street,
                City       = address.City,
                Number     = address.Number,
                CountryId  = country.Id,
                PostalCode = address.PostalCode
            };
        }

        public Domain.DTO.Address ToDTO(Domain.Entities.Address address)
        {
            if (address == null) return null;

            return new Domain.DTO.Address
            {
                City       = address.City,
                Number     = address.Number,
                PostalCode = address.PostalCode,
                Street     = address.Street,
                Country    = countryMapper.ToDTO(address.Country)
            };
        }
    }
}