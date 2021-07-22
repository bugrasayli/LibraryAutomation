using Library.Domain.DTO.Costumer;
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
    public class CostumerService : ICostumerService
    {
        private readonly ICostumerRepository _repo;
        private readonly ICostumerMapper _mapper;

        public CostumerService(ICostumerRepository repo, ICostumerMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<CostumerResponse> Add(AddCostumerRequest costumer)
        {
            var result = _repo.Post(_mapper.Map(costumer));
            await _repo.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(result);
        }
        public async Task<CostumerResponse> Delete(CostumerRequest request)
        {
            var existedReport = await _repo.Get(request.ID);
            if (request == null)
                throw new ArgumentNullException("Costumer cannot found");
            var result = _repo.Delete(existedReport);
            await _repo.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(result);
        }
        public async Task<CostumerResponse> Edit(EditCostumerRequest costumer)
        {
            var existedRecord =await _repo.Get(costumer.ID);
            if (existedRecord == null)
                throw new ArgumentException("Costumer cannot found");
            var record = _repo.Put(_mapper.Map(costumer));
            await _repo.UnitOfWork.SaveChangesAsync();
            return _mapper.Map(record);
        }
        public async Task<CostumerResponse> Get(CostumerRequest request)
        {
            var result = await _repo.Get(request.ID);
            return _mapper.Map(result);
        }
        public async Task<IEnumerable<CostumerResponse>> Get()
        {
            var result = await _repo.Get();
            return result.Select(x=> _mapper.Map(x));
        }
    }
}
