using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MovieClient.Models;

namespace MovieClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DoRESTStuff().Wait();
        }

        private static async Task DoRESTStuff()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:32438/api/Movies");
            client.DefaultRequestHeaders.
                Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("");
            //////////////////////////////////////
            
            if (response.IsSuccessStatusCode)
            {
                // read results 
                var movies = await response.Content.ReadAsAsync<IEnumerable<Movie>>();
                foreach (var movie in movies)
                {
                    Console.WriteLine(movie.Title);
                }
            }
            else
            {
                Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
            }
/*
            //POST
            Movie mv = new Movie() { Title = "Ryan's Daughter", Genre = "Oirish", Cert = Certificate.Twelve, ReleaseDate = new DateTime(1970, 3, 17), Rating = 8 };
            response = await client.PostAsJsonAsync("", mv);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Movie {0} added", mv.Title);
            }
            else
            {
                Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);

            }
            */
            //PUT
            Movie mvx = new Movie() { Title = "Brexit Rearranged", Genre = "European", Cert = Certificate.Twelve, ReleaseDate = new DateTime(2022, 6, 1), Rating = 8 };
            response = await client.PutAsJsonAsync("",  mvx);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Movie {0} added", mvx.Title);
            }
            else
            {
                Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);

            }
        }
    }
}
