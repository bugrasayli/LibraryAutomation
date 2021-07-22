using Library.Domain.DTO.Costumer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.IValidation
{
    public interface ICostumerValidation
    {
        string AddCostumerValidation(AddCostumerRequest costumer);
        string EditCostumerValidation(EditCostumerRequest costumer);

    }
}
