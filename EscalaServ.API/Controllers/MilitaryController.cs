﻿using EscalaServ.Application.Commands.CreateMilitary;
using EscalaServ.Application.Commands.CreateTrade;
using EscalaServ.Application.Commands.DeleteMilitary;
using EscalaServ.Application.Commands.UpdateMilitary;
using EscalaServ.Application.Queries.GetAllMilitary;
using EscalaServ.Application.Queries.GetMilitaryById;
using EscalaServ.Application.Queries.GetTrades;
using EscalaServ.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EscalaServ.API.Controllers
{
    [Route("api/militaries")]
    public class MilitaryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MilitaryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //api/militaries?query="parâmetro de busca"
        [HttpGet]
        [Authorize(Roles = "admin, default")]
        public async Task<IActionResult> Get(string query)
        {
            var command = new GetAllMilitaryQuery(query);
            var military = await _mediator.Send(command);

            return Ok(military);
        }

        //api/militaries/"id"
        [HttpGet("{id}")]
        [Authorize(Roles = "admin, default")]
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
        [Authorize(Roles = "admin, default")]
        public async Task<IActionResult> GetAll(int id, string query)
        {
            var command = new GetAllTradesByUserIdQuery(id,query);

            var trade = await _mediator.Send(command);

            if (trade == null)
            {
                return NotFound();
            }
            return Ok(trade);


        }

        //api/militaries/
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task <IActionResult> Post([FromBody] CreateMilitaryCommand command)
        {
            //Possíveis retornos:

            //BadRequest, caso algum requisito dos parâmetros não seja atendido
            //Ex.: NomeDeGuerra deve ter no máximo 20 caracteres, se for inserido algum com 21, retornará BadRequest

            //CreatedAtAction, equivalente ao 201 (Created)

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        //api/militaries/"id"/trades
        [HttpPost("{id}/trades")]
        [Authorize(Roles = "admin, default")]
        public async Task<IActionResult> Post([FromBody] CreateTradeCommand command)
        {

            await _mediator.Send(command);

            return NoContent();
        }

        //api/militaries/"id"
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put([FromBody] UpdateMilitaryCommand command, int id)
        {
            if (command.Id != id)
            {
                return BadRequest();
            }
            await _mediator.Send(command);

            return NoContent();
        }

        //api/militaries/"id"
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMilitaryCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
