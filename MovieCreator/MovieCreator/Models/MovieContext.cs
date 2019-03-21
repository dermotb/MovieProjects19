using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCreator.Models
{
    class MovieContext : DbContext
    {
        public DbSet<Movie> MovieSet { get; set; }
    }
}
