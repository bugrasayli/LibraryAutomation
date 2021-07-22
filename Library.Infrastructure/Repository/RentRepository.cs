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
    public class RentRepository : IRentRepository
    {
        private readonly LibraryContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public RentRepository(LibraryContext context)
        {
            _context = context;
        }


        public Rent Delete(Rent rent)
        {
            var result = _context.Rent.Remove(rent).Entity;
            return result;
        }

        public Rent Edit(Rent rent)
        {
            _context.Entry(rent).State = EntityState.Modified;
            return rent;
        }

        public async Task<IEnumerable<Rent>> Get()
        {
            var result = await _context.Rent.AsNoTracking()
                .Include(x => x.Book)
                .Include(x => x.Costumer)
                .ToListAsync();
            return result;
        }

        public async Task<Rent> Get(int ID)
        {
            var result = await _context.Rent.Where(x => x.ID == ID)
                .Include(x => x.Book)
                .Include(x => x.Costumer)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return result;
        }

        public Rent Post(Rent rent)
        {
            var result = _context.Rent.Add(rent).Entity;
            return result;
        }
    }
}
