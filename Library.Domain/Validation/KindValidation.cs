using Library.Domain.DTO.Address;
using Library.Domain.DTO.Kind;
using Library.Domain.Entities;
using Library.Domain.IValidation;
using System;

namespace Library.Domain.Validation
{
    public class KindValidation : IKindValidation
    {
        public string AddKindValidation(AddKindRequest kind)
        {
            if (kind == null)
                return "Kind object is empty";
            if (kind.Name == null || kind.Name.Equals(""))
                return "Kind name cannot be empty or null";
            return null;
        }
        public string EditKindValidation(EditKindRequest kind)
        {
            if (kind == null)
                return "Kind object is empty";
            if (kind.Name == null || kind.Name.Equals("") || kind.ID == 0)
                return "Kind name is empty or null";
            return null;
        }
    }
}
