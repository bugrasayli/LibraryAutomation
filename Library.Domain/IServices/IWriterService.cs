using Library.Domain.DTO.Book;
using Library.Domain.DTO.Writer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.IServices
{
    public interface IWriterService
    {
        Task<IEnumerable<WriterResponse>> Get();
        Task<WriterResponse> Get(WriterRequest request);
        Task<WriterResponse> Add(AddWriterRequest writer);
        Task<WriterResponse> Edit(EditWriterRequest writer);
        Task<WriterResponse> Delete(WriterRequest request);
        Task<IEnumerable<BookResponse>> GetBookByWriter(WriterRequest request);

    }
}
