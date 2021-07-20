using Library.Domain.DTO.Writer;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IRepository
{
    public interface IWriterRepository :IRepository
    {
        Task<IEnumerable<Writer>> Get();
        Task<IEnumerable<Book>> GetBookByWriter(int ID);
        Task<Writer> Get(int ID);
        Writer Add(Writer writer);
        Writer Edit(Writer writer);
        Writer Delete(Writer writer);
    }
}
