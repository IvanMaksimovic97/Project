using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGetGenresCommand getGenres;
        private readonly ICreateGenreCommand createGenre;
        private readonly IDeleteGenreCommand deleteGenre;

        // GET: api/Genres
        [HttpGet]
        public IActionResult Get([FromQuery] GenreDTO dto)
        {
            try
            {
                var actors = getGenres.Execute(dto);
                return Ok(actors);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET: api/Genres/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Genres
        [HttpPost]
        public IActionResult Post([FromBody] CreateGenreDTO request)
        {
            try
            {
                createGenre.Execute(request);
                return StatusCode(201);
            }
            catch (EntityAlreadyExist e)
            {
                return StatusCode(409, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Greska");
            }
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteGenre.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
