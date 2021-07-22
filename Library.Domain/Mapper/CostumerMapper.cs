using Library.Domain.DTO.Costumer;
using Library.Domain.Entities;
using Library.Domain.IMapper;
using Library.Domain.IValidation;
using System;

namespace Library.Domain.Mapper
{
    public class CostumerMapper : ICostumerMapper
    {
        private readonly ICostumerValidation _valid;

        public CostumerMapper(ICostumerValidation valid)
        {
            _valid = valid;
        }

        public Costumer Map(AddCostumerRequest costumer)
        {
            var isValid = _valid.AddCostumerValidation(costumer);
            if (isValid != null)
                throw new ArgumentException(isValid);
            return new Costumer
            {
                Name = costumer.Name,
                Surname = costumer.Surname,
                Email = costumer.Email
            };
        }

        public CostumerResponse Map(Costumer costumer)
        {
            if (costumer == null)
                return null;
            return new CostumerResponse
            {
                ID = costumer.ID,
                Name = costumer.Name,
                Surname = costumer.Surname,
                Email = costumer.Email
            };
        }

        public Costumer Map(EditCostumerRequest costumer)
        {
            var isValid = _valid.EditCostumerValidation(costumer);
            if (isValid != null)
                throw new ArgumentException(isValid);
            return new Costumer
            {
                ID = costumer.ID,
                Name = costumer.Name,
                Surname = costumer.Surname,
                Email = costumer.Email
            };
        }
    }
}
