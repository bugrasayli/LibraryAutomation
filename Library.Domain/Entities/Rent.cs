using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class Rent
    {
        public int ID { get; set; }
        public DateTime Rented { get; set; }
        public DateTime DeliverTime { get; set; }
        public bool Delivered { get; set; }

        public int CostumerID { get; set; }
        public int BookID { get; set; }

        public Costumer Costumer { get; set; }
        public Book Book { get; set; }
    }
}
