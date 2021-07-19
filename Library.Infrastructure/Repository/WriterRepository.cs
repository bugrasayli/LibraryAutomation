using Library.Domain.Entities;
using Library.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repository
{
    public class WriterRepository : IWriterRepository
    {
        private readonly LibraryContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public WriterRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Writer>> Get()
        {
            var result = await _context.Writer.ToListAsync();
            return result;
        }

        public async Task<Writer> Get(int ID)
        {
            var result = await _context.Writer.AsNoTracking().FirstOrDefaultAsync(x => x.ID == ID);
            return result;
        }

        public Writer Post(Writer writer)
        {
            var result = _context.Writer.Add(writer).Entity;
            return result;
        }

        public Writer Edit(Writer writer)
        {
            _context.Entry(writer).State = EntityState.Modified;
            return writer;
        }

        public Writer Delete(Writer writer)
        {
            _context.Writer.Remove(writer);
            return writer;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
            UnitOfWork.Dispose();
        }
    }
}
