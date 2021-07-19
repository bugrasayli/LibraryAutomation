using Library.Domain.DTO.Book;
using Library.Domain.Entities;
using Library.Domain.IMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Mapper
{
    public class BookMapper : IBookMapper
    {
        private readonly IWriterMapper _writerMapper;
        private readonly IKindMapper _kindMapper;

        public BookMapper(IWriterMapper writerMapper, IKindMapper kindMapper)
        {
            _writerMapper = writerMapper;
            _kindMapper = kindMapper;
        }

        public Book Map(AddBookRequest book)
        {
            if (book == null)
                return null;
            return new Book
            {
                Name = book.Name,
                Stock =book.Stock,
                KindId = book.KindId,
                WriterId = book.KindId,
            };
        }
        public Book Map(EditBookRequest book)
        {
            if (book == null)
                return null;
            return new Book
            {
                Name = book.Name,
                Stock = book.Stock,
                KindId = book.KindId,
                WriterId = book.KindId,
            };
        }
        public BookResponse Map(Book book)
        {
            if (book == null)
                return null;
            return new BookResponse
            {
                ID = book.ID,
                Name = book.Name,
                Kind = _kindMapper.Map(book.Kind),
                Writer = _writerMapper.Map(book.Writer)
            };
        }
    }
}
