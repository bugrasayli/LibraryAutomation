using Library.Domain.DTO.Book;
using Library.Domain.Entities;

namespace Library.Domain.Validation
{
    public interface IBookValidation
    {
        string AddBookValidation(AddBookRequest book);
        string EditBookValidation(EditBookRequest book);
        string StockBookValidation(Book book);
    }
}
