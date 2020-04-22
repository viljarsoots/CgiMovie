using Microsoft.EntityFrameworkCore;
using SimpleMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMovie.Data
{
    public class MovieAppContext : DbContext
    {
        public MovieAppContext(DbContextOptions<MovieAppContext> options)
            : base(options)
        {
        }

        public MovieAppContext()
        {
        }
        
        

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
