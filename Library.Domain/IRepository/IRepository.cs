using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.IRepository
{
    public interface IRepository
    {
        public IUnitOfWork UnitOfWork{ get; }
    }
}
