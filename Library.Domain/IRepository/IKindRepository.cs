using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IRepository
{
    public interface IKindRepository :IRepository
    {
        Task<Kind> Get(int id);
        Task<IEnumerable<Kind>> Get();
        Task<IEnumerable<Book>> GetBookByKind(int ID);
        Kind Add(Kind kind);
        Kind Edit(Kind kind);
        Kind Delete(Kind kind);
    }
}
