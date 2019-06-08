using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IGetMoviesCommand getMovies;
        private readonly ICreateMovieCommand createMovie;

        public MoviesController(IGetMoviesCommand getMovies, ICreateMovieCommand createMovie)
        {
            this.getMovies = getMovies;
            this.createMovie = createMovie;
        }




        // GET: api/Movies
        [HttpGet]
        public IActionResult Get([FromQuery] MovieSearch search)
        {
            try
            {
                var movies = getMovies.Execute(search);
                return Ok(movies);

            }catch(Exception e)
            {
                return StatusCode(500, "Doslo je do greske");
            }
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Movies
        [HttpPost]
        public void Post([FromForm] CreateMovieDTO dto)
        {
            createMovie.Execute(dto);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
