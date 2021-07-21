using Library.Domain.DTO.Writer;
using Library.Domain.Entities;

namespace Library.Domain.IValidation
{
    public interface IWriterValidation
    {
        string AddWriterValidation(AddWriterRequest writer);
        string EditWriterValidation(EditWriterRequest writer);
    }
}
