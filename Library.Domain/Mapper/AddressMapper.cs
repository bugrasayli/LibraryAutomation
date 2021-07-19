using Library.Domain.DTO.Address;
using Library.Domain.Entities;
using Library.Domain.IMapper;

namespace Library.Domain.Mapper
{
    public class AddressMapper : IAddressMapper
    {
        public Address Map(AddAddressRequest address)
        {
            if (address == null)
                return null;
            return new Address
            {
                Detail = address.Detail
            };
        }

        public Address Map(EditAddressRequest address)
        {
            if (address == null)
                return null;
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
