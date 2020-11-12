using NXCare.Domain.Interfaces.Mappers;
using NXCare.Domain.Interfaces.Repositories.NXCare;
using NXCare.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace NXCare.Services.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IPatientAddressRepository patientAddressRepository;
        private readonly IPatientRepository patientRepository;
        private readonly IAddressMapper addressMapper;

        public AddressService(IPatientAddressRepository patientAddressRepository, IPatientRepository patientRepository, IAddressMapper addressMapper)
        {
            this.patientAddressRepository = patientAddressRepository;
            this.patientRepository        = patientRepository;
            this.addressMapper            = addressMapper;
        }

        public async Task AddOrUpdatePatientAddress(Guid patientId, Domain.DTO.Address address)
        {
            var existingPatientAddress = await patientAddressRepository.GetPatientAndAddressByPatientPublicId(patientId);

            if (existingPatientAddress == null)
            {
                await AddPatientAddressAsync(patientId, address).ConfigureAwait(false);
            }
            else
            {
                await UpdatePatientAddressAsync(address, existingPatientAddress);
            }

            await patientAddressRepository.SaveChangesAsync().ConfigureAwait(false);
        }

        private async Task AddPatientAddressAsync(Guid patientId, Domain.DTO.Address address)
        {
            var patient              = await patientRepository.GetByPublicIdAsync(patientId);
            var patientAddressEntity = new Domain.Entities.PatientAddress()
            {
                Patient = patient,
                Address = await addressMapper.ToEntityAsync(address).ConfigureAwait(false)
            };
            patientAddressRepository.Add(patientAddressEntity);
        }

        private async Task UpdatePatientAddressAsync(Domain.DTO.Address address, Domain.Entities.PatientAddress patientAddressEntity)
        {
            var addressOfPatient            = await addressMapper.ToEntityAsync(address);
            patientAddressEntity.Address    = addressOfPatient;
            patientAddressEntity.Address.Id = patientAddressEntity.AddressId;
            patientAddressRepository.Update(patientAddressEntity);
        }
    }
}
