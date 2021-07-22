using Library.Domain.Entities;
using Library.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repository
{
    public class CostumerRepository : ICostumerRepository
    {
        private LibraryContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public CostumerRepository(LibraryContext context)
        {
            _context = context;
        }
        public Costumer Delete(Costumer costumer)
        {
            var result = _context.Costumer.Remove(costumer).Entity;
            return result;
        }
        public async Task<IEnumerable<Costumer>> Get()
        {
            var result =await _context.Costumer.AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<Costumer> Get(int ID)
        {
            var result = await _context.Costumer.Where(x=> x.ID == ID).AsNoTracking().FirstOrDefaultAsync();
            return result;
        }
        public async Task<IEnumerable<Costumer>> Get(string Email)
        {
            var result = await _context.Costumer.Where(x=> x.Email.Contains(Email)).AsNoTracking().ToListAsync();
            return result;
        }
        public Costumer Post(Costumer costumer)
        {
            var result = _context.Costumer.Add(costumer).Entity;
            return result;
        }
        public Costumer Put(Costumer costumer)
        {
            _context.Entry(costumer).State = EntityState.Modified;
            return costumer;
        }
    }
}
