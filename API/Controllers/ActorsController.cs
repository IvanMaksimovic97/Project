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
    public class ActorsController : ControllerBase
    {
        private readonly ICreateActorCommand createActor;
        private readonly IDeleteActorCommand deleteActor;

        public ActorsController(ICreateActorCommand createActor, IDeleteActorCommand deleteActor)
        {
            this.createActor = createActor;
            this.deleteActor = deleteActor;
        }

        // GET: api/Actors
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Actors/5
        /*[HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST: api/Actors
        [HttpPost]
        public IActionResult Post([FromForm] ActorDTO value)
        {
            try
            {
                createActor.Execute(value);
                return StatusCode(201);
            }
            catch(EntityAlreadyExist e)
            {
                return StatusCode(409, "Glumac postoji");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Greska");
            }
        }

        // PUT: api/Actors/5
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
                deleteActor.Execute(id);
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
