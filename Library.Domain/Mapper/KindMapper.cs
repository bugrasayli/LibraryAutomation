using Library.Domain.DTO.Kind;
using Library.Domain.Entities;
using Library.Domain.IMapper;
using Library.Domain.IValidation;
using System;

namespace Library.Domain.Mapper
{
    public class KindMapper : IKindMapper
    {
        private readonly IKindValidation _kindValidation;

        public KindMapper(IKindValidation kindValidation)
        {
            _kindValidation = kindValidation;
        }

        public Kind Map(AddKindRequest kind)
        {
            var isValid = _kindValidation.AddKindValidation(kind);
            if (isValid != null)
                throw new ArgumentException(isValid);
            if (kind == null)
                return null;
            return new Kind{
                Name = kind.Name
            };
        }
        public Kind Map(EditKindRequest kind)
        {
            var isValid = _kindValidation.EditKindValidation(kind);
            if (isValid != null)
                throw new ArgumentException(isValid);
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
