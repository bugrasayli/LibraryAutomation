using Library.Domain.DTO.Book;
using Library.Domain.DTO.Kind;
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
    public class KindService : IKindService
    {
        private readonly IKindMapper _mapper;
        private readonly IBookMapper _mapperBook;
        private readonly IKindRepository _kind;

        public KindService(IKindMapper mapper, IKindRepository kind, IBookMapper mapperBook)
        {
            _mapper = mapper;
            _mapperBook = mapperBook;
            _kind = kind;
        }

        public async Task<KindResponse> Add(AddKindRequest kind)
        {
            var result = _kind.Add(_mapper.Map(kind));
            await _kind.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(result);
        }

        public async Task<KindResponse> Delete(KindResponse request)
        {
            var existedRecord = await _kind.Get(request.ID);
            if (existedRecord == null)
                throw new ArgumentException("Kind couldn't find");

            var entity = _kind.Delete(existedRecord);
            await _kind.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(entity);
        }

        public async Task<KindResponse> Edit(EditKindRequest kind)
        {
            var existedRecord = await _kind.Get(kind.ID);
            if (existedRecord == null)
                throw new ArgumentException("Book couldn't find");
            var entity = _kind.Edit(_mapper.Map(kind));
            await _kind.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(entity);
        }

        public async Task<IEnumerable<KindResponse>> Get()
        {
            var result = await _kind.Get();
            return result.Select(x => _mapper.Map(x));
        }

        public async Task<KindResponse> Get(KindRequest request)
        {
            var result = await _kind.Get(request.ID);
            return _mapper.Map(result);
        }

        public async Task<IEnumerable<BookResponse>> GetBookByKind(KindRequest request)
        {
            var result = await _kind.GetBookByKind(request.ID);
            return result.Select(x => _mapperBook.Map(x));
        }
    }
}
