using Library.Domain.DTO.Rent;
using Library.Domain.IValidation;

namespace Library.Domain.Validation
{
    public class RentValidation : IRentValidation
    {
        public string AddRentValidation(AddRentRequest rent)
        {
            if (rent == null)
                return "Rent object is null";
            if (rent.BookId == 0)
                return "Book ID is 0 ";
            if (rent.CostumerId == 0)
                return "Costumer ID is 0";
            return null;
        }

        public string EditRentValidation(EditRentRequest rent)
        {
            if (rent == null)
                return "Rent object is null";
            if (rent.BookId == 0)
                return "Book ID is 0 ";
            if (rent.CostumerId == 0)
                return "Costumer ID is 0";

            return null;
        }
    }
}
