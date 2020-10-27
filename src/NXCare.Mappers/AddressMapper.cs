using NXCare.Domain.Entities;
using System;
using System.Threading.Tasks;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Mappers
{
    public class AddressMapper
    {
        private readonly ICountryRepository countryRepository;

        public AddressMapper(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public async Task<Address> ToEntityAsync(Domain.DTO.Address address)
        {
            var country = await countryRepository.GetByIdAlpha2CodeAsync(address.Country.Alpha2Code).ConfigureAwait(false);

            return new Address()
            {
                Street = address.Street,
                City = address.City,
                Number = address.Number,
                CountryId = country.Id,
                PostalCode = address.PostalCode
            };
        }
    }
}