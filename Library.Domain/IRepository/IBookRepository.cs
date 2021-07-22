using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IRepository
{
    public interface IBookRepository : IRepository
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int ID);
        Task<Book> GetBookStock(int ID);
        Task<IEnumerable<Rent>> GetRents(int ID);
        Book Add(Book book);
        Book Edit(Book book);
        Book Delete(Book book);

    }
}
