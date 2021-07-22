using Library.Domain.DTO.Book;
using Library.Domain.Entities;

namespace Library.Domain.Validation
{
    public class BookValidation : IBookValidation
    {
        public string AddBookValidation(AddBookRequest book)
        {
            if (book == null)
                return "Book object is empty";
            if (book.Name == null || book.Name.Equals(""))
                return "Book name is null or empty";
            if (book.KindId == 0 || book.WriterId == 0)
                return "KindID or BookID cannot be 0";
            return null;
        }
        public string EditBookValidation(EditBookRequest book)
        {
            if (book == null)
                return "Book object is empty";
            if (book.Name == null || book.Name.Equals(""))
                return "Book name is null or empty";
            if (book.ID == 0)
                return "Book ID cannot be empty";
            if(book.KindId ==0 || book.WriterId ==0)
                return "KindID or BookID cannot be 0";
            return null;

        }

        public string StockBookValidation(Book book)
        {
            if (book == null)
                return "Book couldn't find";
            return null;
        }
    }
}
