using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMovie.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string description { get; set; }
        public string rating { get; set; }
        public List<int> categoryId  { get; set; }
    }
}
