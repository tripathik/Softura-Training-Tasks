using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCusgDPR.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public double Price { get; set; }
    }
}