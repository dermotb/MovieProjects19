using MovieCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie m1 = new Movie() { Title = "The Quiet Man", Genre = "Oirish", Cert = Certificate.Universal, Rating = 8, ReleaseDate = new DateTime(1952, 3, 17) };
            Movie m2 = new Movie() { Title = "Darby O'Gill", Genre = "Oirish", Cert = Certificate.Universal, Rating = 8, ReleaseDate = new DateTime(1959, 3, 17) };
            Movie m3 = new Movie() { Title = "Far And Away", Genre = "Oirish", Cert = Certificate.Universal, Rating = 8, ReleaseDate = new DateTime(1992, 3, 17) };

            MovieContext mvContext = new MovieContext();
            mvContext.MovieSet.Add(m1);
            mvContext.MovieSet.Add(m2);
            mvContext.MovieSet.Add(m3);
            mvContext.SaveChanges();
        }
    }
}
