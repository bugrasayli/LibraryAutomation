using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.DTO.Book
{
    public class AddBookRequest
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public int KindId { get; set; }
        public int WriterId { get; set; }
    }
}
