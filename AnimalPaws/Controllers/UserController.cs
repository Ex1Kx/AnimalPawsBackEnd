using AnimalPaws.Data.Repositories;
using AnimalPaws.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalPaws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInterface _users;

        public UserController(UserInterface userInterface)
        {
            _users = userInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _users.GetUsers());
        }
        [HttpPost]
        public async Task<IActionResult> createUser([FromBody] Users users)
        {
            if (users == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _users.createUser(users);
            return Created("created", created);
        }
        [HttpPut]
        public async Task<IActionResult> updateUser([FromBody] Users users)
        {
            if (users == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _users.updateUser(users);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            await _users.deleteUser(new Users() { id = id });

            return NoContent();
        }
    }
}
