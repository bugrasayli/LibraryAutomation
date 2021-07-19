using Library.Domain.DTO.Kind;
using Library.Domain.Entities;
using Library.Domain.IMapper;

namespace Library.Domain.Mapper
{
    public class KindMapper : IKindMapper
    {
        public Kind Map(AddKindRequest kind)
        {
            if (kind == null)
                return null;
            return new Kind{
                Name = kind.Name
            };
        }
        public Kind Map(EditKindRequest kind)
        {
            if (kind == null)
                return null;

            return new Kind{
                ID = kind.ID,
                Name = kind.Name
            };
        }
        public KindResponse Map(Kind kind)
        {
            if (kind == null)
                return null;
            return new KindResponse{
                ID = kind.ID,
                Name = kind.Name
            };
        }
    }
}
