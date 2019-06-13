using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using EntityFramework_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly Context baza;
        private readonly IGetMoviesCommand getMovies;
        private readonly ICreateMovieCommand createMovie;
        private readonly IDeleteMovieCommand deleteMovie;
        private readonly IEditMovieCommand editMovie;

        public MoviesController(Context baza, IGetMoviesCommand getMovies, ICreateMovieCommand createMovie, IDeleteMovieCommand deleteMovie, IEditMovieCommand editMovie)
        {
            this.getMovies = getMovies;
            this.createMovie = createMovie;
            this.deleteMovie = deleteMovie;
            this.editMovie = editMovie;
            this.baza = baza;
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
                return StatusCode(500, e.Message);
            }
        }

        // GET: api/Movies/5
        /*[HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST: api/Movies
        [HttpPost]
        public IActionResult Post([FromForm] CreateMovieDTO dto)
        {
            try
            {
                createMovie.Execute(dto);
                return StatusCode(201);

            }catch(EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] EditMovieDTO dto)
        {
            try
            {
                var movie = baza.Movies.Find(id);
                if (movie == null)
                    return NotFound();

                editMovie.Execute(dto);
                return NoContent();

            }
            catch (EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteMovie.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
