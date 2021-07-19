using Library.Domain.DTO.Writer;
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
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository _repo;
        private readonly IWriterMapper _mapper;

        public WriterService(IWriterRepository repo, IWriterMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<WriterResponse> Add(AddWriterRequest writer)
        {
            var result = _repo.Post(_mapper.Map(writer));
            await _repo.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(result);
        }
        public async Task<WriterResponse> Delete(WriterRequest request)
        {
            var existedRecord = await _repo.Get(request.ID);
            if (existedRecord == null)
                throw new ArgumentException("Writer cannot found");
            var record = _repo.Delete(existedRecord);
            await _repo.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(record);
        }
        public async Task<WriterResponse> Edit(EditWriterRequest writer)
        {
            var existedRecord = await _repo.Get(writer.ID);
            if (existedRecord == null)
                throw new ArgumentException("Writer cannot found");
            var entity = _mapper.Map(writer);
            _repo.Edit(entity);
            await _repo.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(entity);
        }
        public async Task<IEnumerable<WriterResponse>> Get()
        {
            var result = await _repo.Get();
            return result.Select(x => _mapper.Map(x));
        }
        public async Task<WriterResponse> Get(WriterRequest request)
        {
            var record = await _repo.Get(request.ID);
            if (request == null)
                throw new ArgumentException("There is no Writer");
            return _mapper.Map(record);
        }
    }
}
