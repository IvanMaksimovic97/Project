using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EntityFramework_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context baza;
        private readonly ICreateUserCommand createUser;
        private readonly IGetUsersCommand getUsers;
        private readonly IEditUserCommand editUser;
        private readonly IDeleteUserCommand deleteUser;

        public UsersController(ICreateUserCommand createUser, IGetUsersCommand getUsers, IEditUserCommand editUser, IDeleteUserCommand deleteUser, Context baza)
        {
            this.createUser = createUser;
            this.getUsers = getUsers;
            this.editUser = editUser;
            this.deleteUser = deleteUser;
            this.baza = baza;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get([FromForm] UserDTO search)
        {
            try
            {
                var users = getUsers.Execute(search);
                return Ok(users);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET: api/Users/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromForm] CreateUserDTO request)
        {
            try
            {
                createUser.Execute(request);
                return StatusCode(201);
            }
            catch (EntityAlreadyExist e)
            {
                return StatusCode(409, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] EditUserDTO dto)
        {
            try
            {
                var user = baza.Users.Find(id);
                if (user == null)
                    return NotFound();

                editUser.Execute(dto);
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteUser.Execute(id);
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
