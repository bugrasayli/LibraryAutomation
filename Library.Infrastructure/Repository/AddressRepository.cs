using Library.Domain.Entities;
using Library.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly LibraryContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public AddressRepository(LibraryContext context)
        {
            _context = context;
        }
        public Address Add(Address address)
        {
            var result = _context.Address.Add(address).Entity;
            return result;
        }

        public Address Delete(Address address)
        {
            var result = _context.Address.Remove(address).Entity;
            return result;
        }

        public async Task<IEnumerable<Address>> Get()
        {
            var result = await _context.Address.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Address> Get(int ID)
        {
            var result = await _context.Address.AsNoTracking().FirstOrDefaultAsync(x => x.ID == ID);
            return result;
        }
        public Address Edit(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            return address;
        }
    }
}
