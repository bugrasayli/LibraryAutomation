using Library.Domain.DTO.Kind;
using Library.Domain.Entities;

namespace Library.Domain.IMapper
{
    public interface IKindMapper
    {
        Kind Map(AddKindRequest kind);
        Kind Map(EditKindRequest kind);
        KindResponse Map(Kind kind);
    }
}
