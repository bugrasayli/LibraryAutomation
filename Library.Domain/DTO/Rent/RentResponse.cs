using Library.Domain.DTO.Book;
using Library.Domain.DTO.Costumer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.DTO.Rent
{
    public class RentResponse
    {
        public int ID { get; set; }
        public DateTime Rented { get; set; }
        public DateTime DeliverTime { get; set; }
        public bool Delivered { get; set; }

        public CostumerResponse Costumer { get; set; }
        public BookResponse Book { get; set; }
    }
}
