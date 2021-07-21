using Library.Domain.DTO.Address;
using Library.Domain.Entities;
using Library.Domain.IMapper;
using Library.Domain.IValidation;
using System;

namespace Library.Domain.Mapper
{
    public class AddressMapper : IAddressMapper
    {
        private readonly IAddressValidation _addressValid;
        public AddressMapper(IAddressValidation addressValid)
        {
            _addressValid = addressValid;
        }
        public Address Map(AddAddressRequest address)
        {
            var isValid = _addressValid.AddAddressValidation(address);
            if (isValid != null)
                throw new ArgumentException(isValid);
            return new Address
            {
                Detail = address.Detail
            };
        }
        public Address Map(EditAddressRequest address)
        {
            var isValid = _addressValid.EditAddressValidation(address);
            if (isValid != null)
                throw new ArgumentException(isValid);
            return new Address
            {
                ID = address.ID,
                Detail = address.Detail
            };
        }
        public AddressResponse Map(Address address)
        {
            if (address == null)
                return null;
            return new AddressResponse
            {
                ID = address.ID,
                Detail = address.Detail

            };
        }
    }
}
