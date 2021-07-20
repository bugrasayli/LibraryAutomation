using Library.Domain.DTO.Address;
using Library.Domain.Entities;
using Library.Domain.IMapper;
using Library.Domain.IRepository;
using Library.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repo;
        private readonly IAddressMapper _mapper;

        public AddressService(IAddressRepository repo, IAddressMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AddressResponse> Add(AddAddressRequest address)
        {
            if (address == null)
                throw new ArgumentException("Address couldn't find");
            var result = _repo.Add(_mapper.Map(address));
            await _repo.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(result);
        }

        public async Task<AddressResponse> Delete(AddressRequest request)
        {
            var existedRecord = await _repo.Get(request.ID);
            if (existedRecord == null)
                throw new ArgumentException("Address couldn't find");
            var record = _repo.Delete(existedRecord);
            await _repo.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(existedRecord);
        }

        public async Task<AddressResponse> Edit(EditAddressRequest address)
        {
            var existedRecord = await _repo.Get(address.ID);
            if (existedRecord  == null)
                throw new ArgumentException("Address couldn't find");
            var record = _repo.Edit(_mapper.Map(address));
            await _repo.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(record);
        }

        public async Task<IEnumerable<AddressResponse>> Get()
        {
            var result = await _repo.Get();
            return result.Select(x => _mapper.Map(x));
        }

        public async Task<AddressResponse> Get(AddressRequest request)
        {
            var result = await _repo.Get(request.ID);
            return _mapper.Map(result);
        }
    }
}
