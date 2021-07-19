using Library.Domain.DTO.Book;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.IMapper
{
    public interface IBookMapper
    {
        Book Map(AddBookRequest book);
        Book Map(EditBookRequest book);
        BookResponse Map(Book book);
    }
}
