using Library.Domain.DTO.Kind;
using Library.Domain.Entities;

namespace Library.Domain.IValidation
{
    public interface IKindValidation
    {
        string AddKindValidation(AddKindRequest address);
        string EditKindValidation(EditKindRequest address);
    }
}
