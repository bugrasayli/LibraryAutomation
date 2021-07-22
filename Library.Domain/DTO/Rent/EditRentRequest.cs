using System;

namespace Library.Domain.DTO.Rent
{
    public class EditRentRequest
    {
        public int ID { get; set; }
        public int BookId { get; set; }
        public int CostumerId { get; set; }
        public bool Delivered { get; set; }
        public DateTime DeliverTime{ get; set; }
        public DateTime Rented{ get; set; }
    }
}
