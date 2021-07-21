using Library.Domain.DTO.Book;
using Library.Domain.Entities;
using Library.Domain.IMapper;
using Library.Domain.Validation;
using System;

namespace Library.Domain.Mapper
{
    public class BookMapper : IBookMapper
    {
        private readonly IWriterMapper _writerMapper;
        private readonly IKindMapper _kindMapper;
        private readonly IBookValidation _bookValidation;


        public BookMapper(IWriterMapper writerMapper, IKindMapper kindMapper,IBookValidation bookValidation)
        {
            _writerMapper = writerMapper;
            _kindMapper = kindMapper;
            _bookValidation = bookValidation;
        }
        public Book Map(AddBookRequest book)
        {
            var isValid = _bookValidation.AddBookValidation(book);
            if (isValid != null)
                throw new ArgumentException(isValid);
            return new Book
            {
                Name = book.Name,
                Stock =book.Stock,
                KindId = book.KindId,
                WriterId = book.WriterId,
            };
        }
        public Book Map(EditBookRequest book)
        {
            var isValid = _bookValidation.EditBookValidation(book);
            if (isValid != null)
                throw new ArgumentException(isValid);
            return new Book
            {
                ID = book.ID,
                Name = book.Name,
                Stock = book.Stock,
                KindId = book.KindId,
                WriterId = book.WriterId
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
                Stock =book.Stock,
                Kind = _kindMapper.Map(book.Kind),
                Writer = _writerMapper.Map(book.Writer)
            };
        }
    }
}
