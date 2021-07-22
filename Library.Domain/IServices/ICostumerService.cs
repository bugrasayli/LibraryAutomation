
using Library.Domain.DTO.Costumer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.IServices
{
    public interface ICostumerService
    {
        Task<CostumerResponse> Get(CostumerRequest request);
        Task<IEnumerable<CostumerResponse>> Get();
        Task<CostumerResponse> Edit(EditCostumerRequest costumer);
        Task<CostumerResponse> Add(AddCostumerRequest costumer);
        Task<CostumerResponse> Delete(CostumerRequest request);
    }
}
