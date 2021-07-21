using Library.Domain.DTO.Address;
using Library.Domain.Entities;
using Library.Domain.IValidation;

namespace Library.Domain.Validation
{
    public class AddressValidation : IAddressValidation
    {
        public string AddAddressValidation(AddAddressRequest address)
        {
            if (address == null)
                return "Address object is empty";
            if (address.Detail == null || address.Detail == "")
                return "Address detail null or empty";
            return null;
        }

        public string EditAddressValidation(EditAddressRequest address)
        {
            if (address == null)
                return "Address object is empty";
            if (address.Detail == null || address.Detail == "")
                return "Address detail cannot be empty";
            if (address.ID == 0)
                return "Address ID cannot be 0";
            return null;
        }
    }
}
