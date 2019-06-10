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
    public class CinemasController : ControllerBase
    {
        private readonly ICreateCinemaCommand createCinema;
        private readonly IGetCinemasCommand getCinemas;
        private readonly IDeleteCinemaCommand deleteCinema;

        public CinemasController(ICreateCinemaCommand createCinema, IGetCinemasCommand getCinemas, IDeleteCinemaCommand deleteCinema)
        {
            this.createCinema = createCinema;
            this.getCinemas = getCinemas;
            this.deleteCinema = deleteCinema;
        }


        // GET: api/Cinemas
        [HttpGet]
        public IActionResult Get([FromQuery] CinemaDTO request)
        {
            try
            {
                var cinemas = getCinemas.Execute(request);
                return Ok(cinemas);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Greska");
            }
        }

        // GET: api/Cinemas/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cinemas
        [HttpPost]
        public IActionResult Post([FromForm] CreateCinemaDTO value)
        {
            try
            {
                createCinema.Execute(value);
                return StatusCode(201);
            }catch(EntityAlreadyExist e)
            {
                return StatusCode(409, e.Message);

            }catch(Exception e)
            {
                return StatusCode(500, "Greska");
            }
        }

        // PUT: api/Cinemas/5
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
                deleteCinema.Execute(id);
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
