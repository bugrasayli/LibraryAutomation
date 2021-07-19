using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Stock{ get; set; }
        public int KindId { get; set; }
        public int WriterId { get; set; }

        public Kind Kind { get; set; }
        public Writer Writer{ get; set; }
    }
}
