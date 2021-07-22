using Library.Domain.DTO.Rent;
using Library.Domain.Entities;
using Library.Domain.IMapper;
using Library.Domain.IValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Mapper
{
    public class RentMapper : IRentMapper
    {
        private readonly IRentValidation _rentMapper;
        private readonly ICostumerMapper _costumerMapper;
        private readonly IBookMapper _bookMapper;

        public RentMapper(IRentValidation rentMapper, ICostumerMapper costumerMapper, IBookMapper bookMapper)
        {
            _rentMapper = rentMapper;
            _costumerMapper = costumerMapper;
            _bookMapper = bookMapper;
        }

        public Rent Map(AddRentRequest rent)
        {
            var isValid = _rentMapper.AddRentValidation(rent);
            if (isValid != null)
                throw new ArgumentException(isValid);
            return new Rent
            {
                BookID = rent.BookId,
                CostumerID = rent.CostumerId,
                Rented = DateTime.Now,
                DeliverTime = DateTime.Now.AddDays(7),
                Delivered = false,
            };
        }
        public Rent Map(EditRentRequest rent)
        {
            var isValid = _rentMapper.EditRentValidation(rent);
            if (isValid != null)
                throw new ArgumentException(isValid);
            return new Rent
            {
                ID =rent.ID,
                BookID = rent.BookId,
                CostumerID = rent.CostumerId,
                Rented = rent.Rented,
                DeliverTime = rent.DeliverTime,
                Delivered = rent.Delivered,
            };
        }
        public RentResponse Map(Rent rent)
        {
            if (rent == null)
                return null;
            return new RentResponse
            {
                ID = rent.ID,
                Rented = rent.Rented,
                DeliverTime = rent.DeliverTime,
                Delivered = rent.Delivered,
                Book = _bookMapper.Map(rent.Book),
                Costumer =_costumerMapper.Map(rent.Costumer)
            };

        }
    }
}
