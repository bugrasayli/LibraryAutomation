using Library.Domain.DTO.Book;
using Library.Domain.DTO.Rent;
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
        private readonly IRentMapper _rentMapper;

        public BookService(IBookRepository repo, IBookMapper mapper, IRentMapper rentMapper)
        {
            _repo = repo;
            _mapper = mapper;
            _rentMapper =rentMapper;
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
                throw new ArgumentException("Book couldn't find");
            _repo.Delete(result);
            await _repo.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(result);
        }
        public async Task<BookResponse> Edit(EditBookRequest book)
        {
            var existedRecord = await _repo.Get(book.ID);
            if (existedRecord == null)
                throw new ArgumentException("Book couldn't find");
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
        }
        public async Task<IEnumerable<RentResponse>> GetRents(BookRequest request)
        {
            var result = await _repo.GetRents(request.ID);
            if (result == null)
                return null;
            return result.Select(x => _rentMapper.Map(x));
        }

        }
}
