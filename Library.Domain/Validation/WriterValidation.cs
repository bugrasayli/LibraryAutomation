using Library.Domain.DTO.Writer;
using Library.Domain.Entities;
using Library.Domain.IValidation;

namespace Library.Domain.Validation
{
    public class WriterValidation : IWriterValidation
    {
        public string AddWriterValidation(AddWriterRequest writer)
        {
            if (writer == null)
                return "Writer object is empty";
            if (writer.Name == null || writer.Name.Equals(""))
                return "Writer Name is null or empty";
            return null;
        }
        public string EditWriterValidation(EditWriterRequest writer)
        {
            if (writer == null)
                return "Writer object is null";
            if (writer.Name == null || writer.Name.Equals(""))
                return "Writer Name is null or empty";
            if (writer.ID == 0)
                return "Writer ID cannot be 0";
            return null;
        }
    }
}
