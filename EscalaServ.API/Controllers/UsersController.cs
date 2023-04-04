using EscalaServ.Application.Commands.CreateUser;
using EscalaServ.Application.Commands.UpdateUser;
using EscalaServ.Application.Queries.GetAllUser;
using EscalaServ.Application.Queries.GetUserById;
using EscalaServ.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EscalaServ.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {

            _mediator = mediator;
        }

        //api/user/query="parâmetro de busca"
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var command = new GetAllUsersQuery(query);
            var user = await _mediator.Send(command);

            return Ok(user);
        }

        //api/user/"id"
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetUserByIdQuery(id);
            var user = await _mediator.Send(command);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //api/users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {          
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();

        }

        

        

        

        //api/users/"id"/login
        //[HttpPut("{id}/login")]
        //public IActionResult Login(int id, [FromBody] LoginModel login)
        //{
        //    return NoContent();
        //}
    }
}
