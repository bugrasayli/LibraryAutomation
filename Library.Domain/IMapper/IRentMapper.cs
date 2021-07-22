using Library.Domain.DTO.Rent;
using Library.Domain.Entities;

namespace Library.Domain.IMapper
{
    public interface IRentMapper
    {
        public Rent Map(AddRentRequest rent);
        public Rent Map(EditRentRequest rent);
        RentResponse Map(Rent rent);
    }
}
