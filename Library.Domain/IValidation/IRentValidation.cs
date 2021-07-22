using Library.Domain.DTO.Rent;


namespace Library.Domain.IValidation
{
    public interface IRentValidation
    {
        string AddRentValidation(AddRentRequest rent);
        string EditRentValidation(EditRentRequest rent);


    }
}
