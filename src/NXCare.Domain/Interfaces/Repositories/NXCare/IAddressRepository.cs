using System.Threading.Tasks;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.Base;

namespace NXCare.Domain.Interfaces.Repositories.NXCare
{
    public interface IAddressRepository : IBaseRepository<Address, int>
    {
        Task<Address> GetByAddressInformationAsync(Domain.DTO.Address lookUpAddress);

        Task<Address> GetByAddressInformationAsync(string street, string number, string postalCode, string city, string countryAlpha2Code);
    }
}