using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.DTO.Book
{
    public class EditBookRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int KindId { get; set; }
        public int WriterId { get; set; }
    }
}
