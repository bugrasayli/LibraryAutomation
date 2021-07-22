using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IRepository
{
    public interface IRentRepository :IRepository
    {
        Task<IEnumerable<Rent>> Get();
        Task<Rent> Get(int ID);
        Rent Post(Rent rent);
        Rent Edit(Rent rent);
        Rent Delete(Rent rent);
    }
}
