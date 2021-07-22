using Library.Domain.DTO.Rent;
using Library.Domain.Entities;
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
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepo;
        private readonly IRentMapper _rentMapper;
        private readonly IBookRepository _bookRepo;
        private readonly IBookMapper _bookMapper;
        private readonly ICostumerRepository _costumerRepo;

        public RentService(IRentRepository rentRepo
            , IRentMapper rentMapper, IBookMapper bookMapper
            , IBookRepository bookRepo
            , ICostumerRepository costumerRepo)
        {
            _rentRepo = rentRepo;
            _bookMapper = bookMapper;
            _rentMapper = rentMapper;
            _bookRepo = bookRepo;
            _costumerRepo = costumerRepo;
        }

        public async Task<RentResponse> Add(AddRentRequest rent)
        {
            var bookExisted = await _bookRepo.Get(rent.BookId);

            if (bookExisted == null)
                throw new ArgumentException("There is no book");

            if (bookExisted.Stock == 0)
                throw new ArgumentException("There is no stock");

            var costumer = await _costumerRepo.Get(rent.CostumerId);

            if (costumer == null)
                throw new ArgumentException("There is no costumer");

            var result = _rentRepo.Post(_rentMapper.Map(rent));
            await _rentRepo.UnitOfWork.SaveChangesAsync();

            bookExisted.Stock = bookExisted.Stock - 1;
            _bookRepo.Edit(bookExisted);
            await _bookRepo.UnitOfWork.SaveChangesAsync();

            var existedRecord = await _rentRepo.Get(result.ID);
            return _rentMapper.Map(existedRecord);
        }

        public Task<RentResponse> Delete(RentRequestByID rent)
        {
            throw new NotImplementedException();
        }

        public async Task<RentResponse> Deliver(RentRequestByID rent)
        {
            var existedRecord = await _rentRepo.Get(rent.ID);
            if (existedRecord == null)
                throw new ArgumentException("Rent couldn't find");
            if (existedRecord.Delivered)
                throw new ArgumentException("The book has been also delivered");
            existedRecord.Delivered = true;
            existedRecord.DeliverTime = DateTime.Now;
            var result = _rentRepo.Edit(existedRecord);
            await _rentRepo.UnitOfWork.SaveChangesAsync();

            var existedBook =await _bookRepo.Get(result.BookID);
            existedBook.Stock = existedBook.Stock + 1;
            _bookRepo.Edit(existedBook);
            await _bookRepo.UnitOfWork.SaveChangesAsync();
            return _rentMapper.Map(result);
        }

        public async Task<RentResponse> Edit(EditRentRequest rent)
        {
            var existedRecord =await _rentRepo.Get(rent.ID);

            if (existedRecord == null)
                throw new ArgumentException("Rent couldn't find");

            if (existedRecord.Delivered)
                throw new ArgumentException("Delivered items cannot be changed!");

            rent.Rented = DateTime.Now;
            rent.DeliverTime = DateTime.Now.AddDays(7);

            var result = _rentRepo.Edit(_rentMapper.Map(rent));
            await _rentRepo.UnitOfWork.SaveChangesAsync();

            return _rentMapper.Map(result);
        }

        public async Task<IEnumerable<RentResponse>> Get()
        {
            var result = await _rentRepo.Get();
            return result.Select(x => _rentMapper.Map(x));
        }

        public async Task<RentResponse> Get(RentRequestByID request)
        {
            var result = await _rentRepo.Get(request.ID);
            return _rentMapper.Map(result);
        }
    }
}
