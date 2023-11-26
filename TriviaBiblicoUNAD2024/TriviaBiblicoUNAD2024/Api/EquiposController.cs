using Mapster;
using Microsoft.AspNetCore.Mvc;
using SNashENGINE.Share.Datos;
using SNashENGINE.Share.DTOs.Equipo;
using TriviaBiblicoUNAD2024.Data.Modelos.Equipos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaBiblicoUNAD2024.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        // GET: api/<EquiposController>
        [HttpGet]
        public ActionResult<RequestData<IEnumerable<EquipoDTO>>> Get()
        {
            //Ejemplo de datos que vienen de la BD
            var EquiposModeloFromDb = Enumerable.Empty<EquipoModel>();
            RequestData<IEnumerable<EquipoDTO>> ResultadoRequest = new RequestData<IEnumerable<EquipoDTO>>();

            if (EquiposModeloFromDb is null)
            {
                ResultadoRequest.IsSuccess = false;
                ResultadoRequest.StatusMessage = "Error en la base de datos";
            }
            else if (EquiposModeloFromDb.Count() == 0)
            {
                ResultadoRequest.IsSuccess = true;
                ResultadoRequest.StatusMessage = "No hay registro";
                ResultadoRequest.Data = null;
            }
            else
            {
                ResultadoRequest.IsSuccess = true;
                ResultadoRequest.StatusMessage = null;
                ResultadoRequest.Data = EquiposModeloFromDb.Adapt<EquipoDTO[]>();
            }

            return ResultadoRequest;
        }

        // GET api/<EquiposController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EquiposController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EquiposController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EquiposController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
