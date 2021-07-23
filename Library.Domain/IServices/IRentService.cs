using Library.Domain.DTO.Rent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.IServices
{
    public interface IRentService
    {
        Task<IEnumerable<RentResponse>> Get();
        Task<IEnumerable<RentResponse>> Filter(int book,int costumer,string name,bool? isDelivered,bool? isLate);
        Task<RentResponse> Get(RentRequestByID request);
        Task<RentResponse> Edit(EditRentRequest rent);
        Task<RentResponse> Add(AddRentRequest rent);
        Task<RentResponse> Delete(RentRequestByID rent);
        Task<RentResponse> Deliver(RentRequestByID rent);
    }
}
