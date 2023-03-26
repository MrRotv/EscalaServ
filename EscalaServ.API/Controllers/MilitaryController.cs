using EscalaServ.Application.Commands.CreateMilitary;
using EscalaServ.Application.Commands.CreateTrade;
using EscalaServ.Application.Commands.DeleteMilitary;
using EscalaServ.Application.Commands.UpdateMilitary;
using EscalaServ.Application.InputModels;
using EscalaServ.Application.Queries.GetAllMilitary;
using EscalaServ.Application.Queries.GetMilitaryById;
using EscalaServ.Application.Queries.GetTrades;
using EscalaServ.Application.Services.Implemetations;
using EscalaServ.Application.Services.Interfaces;
using EscalaServ.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EscalaServ.API.Controllers
{
    [Route("api/militaries")]
    public class MilitaryController : ControllerBase
    {
        private readonly IMilitaryService _militaryService;
        private readonly IMediator _mediator;
        public MilitaryController(IMilitaryService militaryService, IMediator mediator)
        {
            _militaryService = militaryService;
            _mediator = mediator;
        }
        //api/militaries?query="parâmetro de busca"
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var command = new GetAllMilitaryQuery(query);
            var military = await _mediator.Send(command);

            return Ok(military);
        }

        //api/militaries/"id"
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetMilitaryByIdQuery(id);

            var military = await _mediator.Send(command);
            
            if (military == null)
            {
                return NotFound();
            }
            return Ok(military);
        }

        [HttpGet("{id}/trades")]
        public async Task<IActionResult> GetAll(int id)
        {
            var command = new GetAllTradesByUserIdQuery(id);

            var trade = await _mediator.Send(command);

            if (trade == null)
            {
                return NotFound();
            }
            return Ok(trade);


        }

        //api/militaries/
        [HttpPost]
        public async Task <IActionResult> Post([FromBody] CreateMilitaryCommand command)
        {
            if (command.Graduation.Length > 20)
            {
                return BadRequest();
            }
            //Possíveis retornos:

            //BadRequest, caso algum requisito dos parâmetros não seja atendido
            //Ex.: NomeDeGuerra deve ter no máximo 20 caracteres, se for inserido algum com 21, retornará BadRequest

            //CreatedAtAction, equivalente ao 201 (Created)

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        //public IActionResult GetById(int id, TradeQuestQuerie querie)
        //{

        //}

        //api/militaries/"id"/trades
        [HttpPost("{id}/trades")]
        public async Task<IActionResult> Post([FromBody] CreateTradeCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        //api/militaries/"id"
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateMilitaryCommand command)
        {
            if (command.Nip.Length > 8)
            {
                return BadRequest();
            }
            await _mediator.Send(command);

            return NoContent();
        }

        //api/militaries/"id"
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMilitaryCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
