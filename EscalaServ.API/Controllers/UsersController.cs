using EscalaServ.API.Models;
using EscalaServ.Application.InputModels;
using EscalaServ.Application.Services.Interfaces;
using EscalaServ.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EscalaServ.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userInterface;
        public UsersController(IUserService userInterface)
        {
            _userInterface = userInterface;
        }

        //api/user/query="parâmetro de busca"
        [HttpGet]
        public IActionResult Get(string query)
        {
            var user = _userInterface.GetAll(query);

            return Ok(user);
        }

        //api/user/"id"
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var user = _userInterface.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //api/users
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel inputModel)
        {
            var id = _userInterface.Create(inputModel);
            return CreatedAtAction(nameof(GetById), new { id }, inputModel);
        }

        //api/users/"id"/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }
    }
}
