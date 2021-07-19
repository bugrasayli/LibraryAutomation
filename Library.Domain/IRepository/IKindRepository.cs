using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IRepository
{
    public interface IKindRepository :IRepository,IUnitOfWork
    {
        Task<Kind> Get(int id);
        Task<IEnumerable<Kind>> Get();
        Kind Post(Kind kind);
        Kind Update(Kind kind);
        Kind Delete(Kind kind);
    }
}
