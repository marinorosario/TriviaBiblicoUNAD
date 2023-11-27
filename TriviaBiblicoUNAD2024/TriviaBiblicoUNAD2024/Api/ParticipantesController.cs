using Mapster;
using Microsoft.AspNetCore.Mvc;
using SNashENGINE.Share.Datos;
using SNashENGINE.Share.DTOs.Equipo;
using SNashENGINE.Share.DTOs.Participantes;
using TriviaBiblicoUNAD2024.Data.Modelos.Participantes;
using TriviaBiblicoUNAD2024.Servicios.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaBiblicoUNAD2024.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        private readonly IDataEngineService<ParticipanteModel> participanteSrv;

        public ParticipantesController(IDataEngineService<ParticipanteModel> _ParticipanteSrv)
        {
            participanteSrv = _ParticipanteSrv;
        }

        // GET: api/<ParticipantesController>
        [HttpGet]
        public async Task<ActionResult<RequestData<IEnumerable<ParticipanteDTO>>>> Get()
        {
            var ParticipantesModeloFromDb = await participanteSrv.GetAllAsync();
            RequestData<IEnumerable<ParticipanteDTO>> ResultadoRequest = new RequestData<IEnumerable<ParticipanteDTO>>();

            if (ParticipantesModeloFromDb is null)
            {
                ResultadoRequest.IsSuccess = false;
                ResultadoRequest.StatusMessage = "Error en la base de datos";
            }
            else if (ParticipantesModeloFromDb.Count() == 0)
            {
                ResultadoRequest.IsSuccess = true;
                ResultadoRequest.StatusMessage = "No hay registro";
                ResultadoRequest.Data = null;
            }
            else
            {
                ResultadoRequest.IsSuccess = true;
                ResultadoRequest.StatusMessage = null;
                ResultadoRequest.Data = ParticipantesModeloFromDb.Adapt<ParticipanteDTO[]>();
            }

            return ResultadoRequest;
        }

        // GET api/<ParticipantesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ParticipantesController>
        [HttpPost]
        public async Task<ActionResult<RequestData<ParticipanteDTO>>> Post([FromBody] ParticipanteInsertarDTO? value)
        {
            RequestData<ParticipanteDTO> requestData = new RequestData<ParticipanteDTO>();
            if (value is not null)
            {
                var resultado = await participanteSrv.CreateAsync(value.Adapt<ParticipanteModel>());
                if (resultado > 0)
                {
                    requestData.IsSuccess = true;
                    requestData.StatusMessage = "Registro creado satisfactoriamente...!";
                    requestData.Data = null;
                }
                else
                {
                    requestData.IsSuccess = false;
                    requestData.StatusMessage = "Error al guardar registro";
                }
            }
            else
            {
                requestData.IsSuccess = false;
                requestData.StatusMessage = "Debes enviar un registro";
            }

            return requestData;
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
