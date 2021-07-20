using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IRepository 
{
    public interface IAddressRepository : IRepository, IUnitOfWork
    {
        Task<IEnumerable<Address>> Get();
        Task<Address> Get(int ID);
        Address Add(Address address);
        Address Update(Address address);
        Address Delete(Address address);
    }
}
