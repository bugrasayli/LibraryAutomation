using Library.Domain.DTO.Address;
using Library.Domain.Entities;

namespace Library.Domain.IValidation
{
    public interface IAddressValidation
    {
        string AddAddressValidation(AddAddressRequest address);
        string EditAddressValidation(EditAddressRequest address);
    }
}
