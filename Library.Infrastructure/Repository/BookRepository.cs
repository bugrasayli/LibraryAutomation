using Library.Domain.Entities;
using Library.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }
        public Book Add(Book book)
        {
            var result = _context.Book.Add(book).Entity;
            return result;
        }
        public Book Delete(Book book)
        {
            var result = _context.Book.Remove(book).Entity;
            return result;
        }
        public Book Edit(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            return book;
        }
        public async Task<IEnumerable<Book>> Get()
        {
            var result = await _context.Book
                .Include(x=>x.Kind)
                .Include(x=> x.Writer)
                .AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<Book> Get(int ID)
        {
            var result = await _context.Book
                .Include(x => x.Kind)
                .Include(x=> x.Writer).
                AsNoTracking().FirstOrDefaultAsync(x=> x.ID  ==ID);
            return result;
        }
    }
}
