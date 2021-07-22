using Library.Domain.DTO.Costumer;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.IMapper
{
    public interface ICostumerMapper
    {
        Costumer Map(AddCostumerRequest costumer);
        Costumer Map(EditCostumerRequest costumer);
        CostumerResponse Map(Costumer costumer); 
    }
}
