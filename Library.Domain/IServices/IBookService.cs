using Library.Domain.DTO.Book;
using Library.Domain.DTO.Rent;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IServices
{
    public interface IBookService
    {
        Task<BookResponse> Add(AddBookRequest book);
        Task<BookResponse> Edit(EditBookRequest book);
        Task<BookResponse> Delete(BookRequest book);
        Task<BookResponse> Get(BookRequest request);
        Task<IEnumerable<BookResponse>> Get();
        Task<IEnumerable<RentResponse>> GetRents(BookRequest request);
    }
}
