using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IRepository
{
    public interface ICostumerRepository : IRepository
    {
        Task<IEnumerable<Costumer>> Get();
        Task<Costumer> Get(int ID);
        Task<IEnumerable<Costumer>> Get(string Email);
        Costumer Post(Costumer costumer);
        Costumer Put(Costumer costumer);
        Costumer Delete(Costumer costumer);
        Task<IEnumerable<Rent>> GetByCostumer(int ID);
    }
}
