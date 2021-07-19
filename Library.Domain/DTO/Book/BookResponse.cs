using Library.Domain.DTO.Kind;
using Library.Domain.DTO.Writer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.DTO.Book
{
    public class BookResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public KindResponse Kind { get; set; }
        public WriterResponse Writer { get; set; }
    }
}
