using Library.Domain.DTO.Writer;
using Library.Domain.Entities;

namespace Library.Domain.IMapper
{
    public interface IWriterMapper
    {
        Writer Map(AddWriterRequest writer);
        Writer Map(EditWriterRequest writer);
        WriterResponse Map(Writer writer);
    }
}
