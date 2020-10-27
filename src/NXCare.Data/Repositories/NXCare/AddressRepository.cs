using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Data.Repositories.NXCare
{
    public class AddressRepository : BaseRepository<Address, int>, IAddressRepository
    {
        /// <inheritdoc />
        public AddressRepository(NXCareContext context) : base(context)
        {
        }

        public Task<Address> GetByAddressInformationAsync(Domain.DTO.Address lookUpAddress)
        {
            return Set
                .Where(a => a.City               == lookUpAddress.City)
                .Where(a => a.Country.Alpha2Code == lookUpAddress.Country.Alpha2Code)
                .Where(a => a.Number             == lookUpAddress.Number)
                .Where(a => a.PostalCode         == lookUpAddress.PostalCode)
                .Where(a => a.Street             == lookUpAddress.Street)
                .FirstOrDefaultAsync();
        }

        public Task<Address> GetByAddressInformationAsync(string street, string number, string postalCode, string city, string countryAlpha2Code)
        {
            return Set
                .Where(a => a.City               == city)
                .Where(a => a.Country.Alpha2Code == countryAlpha2Code)
                .Where(a => a.Number             == number)
                .Where(a => a.PostalCode         == postalCode)
                .Where(a => a.Street             == street)
                .FirstOrDefaultAsync();
        }
    }
}