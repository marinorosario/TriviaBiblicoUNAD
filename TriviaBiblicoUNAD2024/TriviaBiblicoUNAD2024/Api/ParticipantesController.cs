using Microsoft.AspNetCore.Mvc;
using SNashENGINE.Share.DTOs.Participantes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaBiblicoUNAD2024.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        // GET: api/<ParticipantesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ParticipantesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ParticipantesController>
        [HttpPost]
        public void Post([FromBody] ParticipanteInsertarDTO value)
        {

        }

        // PUT api/<ParticipantesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ParticipantesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
