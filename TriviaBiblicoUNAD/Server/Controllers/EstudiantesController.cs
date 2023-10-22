using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TriviaBiblicoUNAD.Server.Datos;
using TriviaBiblicoUNAD.Server.Modelos.Estudiantes;
using TriviaBiblicoUNAD.Shared.DTOs.Estudiante;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaBiblicoUNAD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContexto;
        private readonly IMapper Mapeador;

        public EstudiantesController(ApplicationDbContext _dbcontexto, IMapper _mapeador)
        {
            dbContexto = _dbcontexto;
            Mapeador = _mapeador;
        }




        // GET: api/<EstudiantesController>
        [HttpGet]
        public IEnumerable<EstudianteDTO> Get()
        {
            var resultado = dbContexto.Estudiantes.ToList();
            return Mapeador.Map<EstudianteDTO[]>(resultado);
        }

        // GET api/<EstudiantesController>/5
        [HttpGet("{id}")]
        public EstudianteDTO Get(int id)
        {
            var resultado = dbContexto.Estudiantes.Find(id);
            return Mapeador.Map<EstudianteDTO>(resultado); 
        }

        // GET api/<EstudiantesController>/matricula/20210101
        [HttpGet("matricula/{matricula}")]
        public EstudianteDTO MatriculaGet(string matricula)
        {
            var resultado = dbContexto.Estudiantes.FirstOrDefault(x => x.Matricula.Equals(matricula));
            return Mapeador.Map<EstudianteDTO>(resultado);
        }

        // POST api/<EstudiantesController>
        [HttpPost]
        public async Task Post([FromBody] EstudianteInsertarDTO value)
        {
            var ModeloEstudiante = Mapeador.Map<EstudianteModelo>(value);
            if (ModeloEstudiante is not null)
            {
                await dbContexto.Estudiantes.AddAsync(ModeloEstudiante);
                await dbContexto.SaveChangesAsync();
            }
        }

        // PUT api/<EstudiantesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
