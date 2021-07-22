using Library.Domain.DTO.Address;

namespace Library.Domain.IValidation
{
    public interface IAddressValidation
    {
        string AddAddressValidation(AddAddressRequest address);
        string EditAddressValidation(EditAddressRequest address);
    }
}
