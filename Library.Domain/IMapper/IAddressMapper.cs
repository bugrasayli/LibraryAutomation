using Library.Domain.DTO.Address;
using Library.Domain.Entities;

namespace Library.Domain.IMapper
{
    public interface IAddressMapper
    {
        Address Map(AddAddressRequest address);
        Address Map(EditAddressRequest address);
        AddressResponse Map(Address address);
    }
}
