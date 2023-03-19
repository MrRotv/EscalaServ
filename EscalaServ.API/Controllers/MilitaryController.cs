using EscalaServ.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscalaServ.API.Controllers
{
    [Route("api/militaries")]
    public class MilitaryController : ControllerBase
    {
        //api/militaries?query="parâmetro de busca"
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        //api/militaries/"id"
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        //api/militaries/
        [HttpPost]
        public IActionResult Post([FromBody] AddMilitaryModel addMilitary)
        {
            if (addMilitary.NomeDeGuerra.Length > 20)
            {
                return BadRequest();
            }
            //Possíveis retornos:

            //BadRequest, caso algum requisito dos parâmetros não seja atendido
            //Ex.: NomeDeGuerra deve ter no máximo 20 caracteres, se for inserido algum com 21, retornará BadRequest

            //CreatedAtAction, equivalente ao 201 (Created)

            return CreatedAtAction(nameof(GetById), new { id = addMilitary.Id }, addMilitary);
        }

        //api/militaries/"id"
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateMilitaryModel updateMilitary)
        {
            if (updateMilitary.Nip.Length > 8)
            {
                return BadRequest();
            }

            return NoContent();
        }

        //api/militaries/"id"
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
