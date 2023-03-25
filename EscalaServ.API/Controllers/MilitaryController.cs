using EscalaServ.API.Models;
using EscalaServ.Application.InputModels;
using EscalaServ.Application.Services.Implemetations;
using EscalaServ.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EscalaServ.API.Controllers
{
    [Route("api/militaries")]
    public class MilitaryController : ControllerBase
    {
        private readonly IMilitaryService _militaryService;
        public MilitaryController(IMilitaryService militaryService)
        {
            _militaryService= militaryService;
        }
        //api/militaries?query="parâmetro de busca"
        [HttpGet]
        public IActionResult Get(string query)
        {
            var military = _militaryService.GetAll(query);

            return Ok(military);
        }

        //api/militaries/"id"
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var military = _militaryService.GetById(id);
            
            if (military == null)
            {
                return NotFound();
            }
            return Ok(military);
        }

        //api/militaries/
        [HttpPost]
        public IActionResult Post([FromBody] AddMilitaryInputModel inputModel)
        {
            if (inputModel.Graduation.Length > 20)
            {
                return BadRequest();
            }
            //Possíveis retornos:

            //BadRequest, caso algum requisito dos parâmetros não seja atendido
            //Ex.: NomeDeGuerra deve ter no máximo 20 caracteres, se for inserido algum com 21, retornará BadRequest

            //CreatedAtAction, equivalente ao 201 (Created)

            var id = _militaryService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        //api/militaries/"id"/trades
        [HttpPost("{id}/trades")]
        public IActionResult Post([FromBody] TradeRequestInputModel inputModel)
        {
            _militaryService.CreateRequest(inputModel);

            return NoContent();
        }

        //api/militaries/"id"
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateMilitaryInputModel inputModel)
        {
            if (inputModel.Nip.Length > 8)
            {
                return BadRequest();
            }
            _militaryService.Update(inputModel, id);

            return NoContent();
        }

        //api/militaries/"id"
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _militaryService.Delete(id);
            return NoContent();
        }
    }
}
