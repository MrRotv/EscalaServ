using EscalaServ.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscalaServ.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        //api/user/"id"
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
        //api/users
        [HttpPost]
        public IActionResult Post([FromBody] AddUserModel addUser)
        {
            return CreatedAtAction(nameof(GetById), new { nip = 1 }, addUser);
        }
        //api/users/"id"/trades
        [HttpPost("{id}/trades")]
        public IActionResult Post([FromBody] ServiceTrade serviceTrade)
        {
            return NoContent();
        }

        //api/users/"id"/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }
    }
}
