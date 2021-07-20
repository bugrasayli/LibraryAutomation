using Library.Domain.DTO.Book;
using Library.Domain.IMapper;
using Library.Domain.IRepository;
using Library.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        private readonly IBookMapper _mapper;

        public BookService(IBookRepository repo, IBookMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<BookResponse> Add(AddBookRequest book)
        {
            var result = _repo.Add(_mapper.Map(book));
            await _repo.UnitOfWork.SaveChangesAsync();
            var existedRecord = await Get(new BookRequest { 
            ID = result.ID});
            return existedRecord;
        }
        public async Task<BookResponse> Delete(BookRequest book)
        {
            var result = await _repo.Get(book.ID);
            if (result == null)
                throw new ArgumentException("No Book Found");
            _repo.Delete(result);
            await _repo.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(result);
        }
        public async Task<BookResponse> Edit(EditBookRequest book)
        {
            var existedRecord = await _repo.Get(book.ID);
            if (existedRecord == null)
                throw new ArgumentException("No book Found");
            var result = _repo.Edit(_mapper.Map(book));
            await _repo.UnitOfWork.SaveChangesAsync();
            var record = await Get(new BookRequest {ID = result.ID });
            return record;
        }
        public async Task<BookResponse> Get(BookRequest request)
        {
            var result = await _repo.Get(request.ID);
            return _mapper.Map(result);
        }
        public async Task<IEnumerable<BookResponse>> Get()
        {
            var result = await _repo.Get();
            return result.Select(x => _mapper.Map(x));
            throw new NotImplementedException();
        }
    }
}
