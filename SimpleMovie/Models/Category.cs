﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMovie.Models
{
    public class Category
    {
        public int id { get; set; }

        public string name { get; set; }

       public virtual ICollection<Movie> Movies { get; set; }
    }
}
