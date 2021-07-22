
using Library.Domain.DTO.Costumer;
using Library.Domain.DTO.Rent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.IServices
{
    public interface ICostumerService
    {
        Task<CostumerResponse> Get(CostumerRequestByID request);
        Task<IEnumerable<CostumerResponse>> Get();
        Task<CostumerResponse> Edit(EditCostumerRequest costumer);
        Task<CostumerResponse> Add(AddCostumerRequest costumer);
        Task<CostumerResponse> Delete(CostumerRequestByID request);
        Task<IEnumerable<CostumerResponse>> Get(CostumerRequestByEmail request);
        Task<IEnumerable<RentResponse>> GetByCostumer(CostumerRequestByID request);
    }
}
