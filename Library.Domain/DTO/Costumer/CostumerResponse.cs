using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.DTO.Costumer
{
    public class CostumerResponse
    {
        public  int ID{ get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
