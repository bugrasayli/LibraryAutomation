using Library.Domain.Entities;
using Library.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repository
{
    public class KindRepository : IKindRepository
    {
        private readonly LibraryContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public KindRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<Kind> Get(int id)
        {
            var result = await _context.Kind.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
        public async Task<IEnumerable<Kind>> Get()
        {
            var result = await _context.Kind.AsNoTracking().ToListAsync();
            return result;
        }
        public Kind Add(Kind kind)
        {
            var result = _context.Kind.Add(kind).Entity;
            return result;
        }
        public Kind Edit(Kind kind)
        {
            _context.Entry(kind).State = EntityState.Modified;
            return kind;
        }
        public Kind Delete(Kind kind)
        {
            var Result = _context.Kind.Remove(kind).Entity;
            return Result;
        }
        public async Task<IEnumerable<Book>> GetBookByKind(int ID)
        {
            var result = await _context.Book.Where(x => x.KindId == ID)
                .Include(x => x.Kind)
                .Include(x => x.Writer)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }
    }
}
