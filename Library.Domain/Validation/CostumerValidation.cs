using Library.Domain.DTO.Costumer;
using Library.Domain.IValidation;
using System.Text.RegularExpressions;

namespace Library.Domain.Validation
{
    public class CostumerValidation : ICostumerValidation
    {
        public string AddCostumerValidation(AddCostumerRequest costumer)
        {
            if (costumer == null)
                return "Costumer Object is null";
            if (costumer.Name == null || costumer.Name.Equals(""))
                return "Costumer Name is null or empty";
            if (costumer.Surname == null || costumer.Surname.Equals(""))
                return "Costumer Surname is null or empty";
            if (costumer.Email == null || costumer.Equals(""))
                return "Costumer email is null or empty";
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(costumer.Email);
            if (!match.Success)
                return "Wrong email Format";
            return null;
        }
        public string EditCostumerValidation(EditCostumerRequest costumer)
        {
            if (costumer == null)
                return "Costumer Object is null";
            if (costumer.ID == 0)
                return "Costumer ID cannot be 0";
            if (costumer.Name == null || costumer.Name.Equals(""))
                return "Costumer Name is null or empty";
            if (costumer.Surname == null || costumer.Surname.Equals(""))
                return "Costumer Surname is null or empty";
            if (costumer.Email == null || costumer.Equals(""))
                return "Costumer email is null or empty";
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(costumer.Email);
            if (!match.Success)
                return "Wrong email Format";
            return null;
        }
    }
}
