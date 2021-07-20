using Library.Domain.DTO.Address;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IServices
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressResponse>> Get();
        Task<AddressResponse> Get(AddressRequest request);
        Task<AddressResponse> Add(AddAddressRequest address);
        Task<AddressResponse> Edit(EditAddressRequest address);
        Task<AddressResponse> Delete(AddressRequest request);
    }
}
