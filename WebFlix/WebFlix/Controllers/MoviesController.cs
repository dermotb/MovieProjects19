using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebFlix.Models;

namespace WebFlix.Controllers
{
    [RoutePrefix("api/Movies")]
    public class MoviesController : ApiController
    {
        MyMovieEntities mvContext = new MyMovieEntities();

        // GET: api/Movies
        [Route()]
        public IEnumerable<Movy> Get()
        {
            return mvContext.Movies.OrderBy(p => p.ReleaseDate);
        }

        [Route("ByKeyword/{keyword}")]
        public Movy GetByKeyWord(string keyword)
        {
            return mvContext.Movies.FirstOrDefault(p => p.Title.Contains(keyword));
        }

        // GET: api/Movies/5
        [Route("{id}")]
        public Movy Get(int id)
        {
            return mvContext.Movies.FirstOrDefault(p => p.MovieID == id);
        }

        // POST: api/Movies
        [Route()]
        public HttpResponseMessage Post([FromBody]Movy value)
        {
            if (value == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to read input");
            }
            if (value.Title == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to read title");
            }

            var x = value.Title;
            if (mvContext.Movies.Count(p => p.Title.Equals(value.Title)) != 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Movie " + value.Title + " already in database.");
            }

            mvContext.Movies.Add(value);
            mvContext.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created, "Movie " + value.Title + " added to database.");
        }


        // PUT: api/Movies/5
        [Route()]
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Movy value)
        {
            if (value == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "Failed to read input");
            }

            var record = mvContext.Movies.SingleOrDefault(p => p.MovieID == id);

            if (record == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to find that Movie");
            }

            try
            {
                record.Title = value.Title;
                record.Rating = value.Rating;
                record.ReleaseDate = value.ReleaseDate;
                record.Genre = value.Genre;
                mvContext.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Record updated");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Update operation failed with exception {0}", e.Message);
            }
        }


       [Route()]
        // DELETE: api/Movies/5
        public HttpResponseMessage Delete(int id)
        {
            var record = mvContext.Movies.FirstOrDefault(p => p.MovieID == id);

            if (record == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to find that Movie");
            }

            try
            {
                mvContext.Movies.Remove(record);
                mvContext.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Record deleted");

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "DELETE operation failed with exception {0}", e.Message);
            }
        }
    }


}
