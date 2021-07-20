using Library.Domain.DTO.Book;
using Library.Domain.DTO.Kind;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IServices
{
    public interface IKindService
    {
        Task<IEnumerable<KindResponse>> Get();
        Task<KindResponse> Get(KindRequest request);
        Task<KindResponse> Edit(EditKindRequest kind);
        Task<KindResponse> Add(AddKindRequest kind);
        Task<KindResponse> Delete(KindResponse request);
        Task<IEnumerable<BookResponse>> GetBookByKind(KindRequest request);
        
    }
}
