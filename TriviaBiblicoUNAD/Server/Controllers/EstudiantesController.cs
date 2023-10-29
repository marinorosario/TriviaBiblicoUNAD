using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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



        //Todos los estudiantes
        // GET: api/<EstudiantesController>
        [HttpGet]
        public ActionResult<IEnumerable<EstudianteDTO>> Get()
        {
            var resultado = dbContexto.Estudiantes.Where(e => e.EstaBorrado == false).ToList();

            return Mapeador.Map<EstudianteDTO[]>(resultado);
        }

        // GET api/<EstudiantesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteDTO>> Get(int id)
        {
            var resultado = await dbContexto.Estudiantes.FindAsync(id);
            return Mapeador.Map<EstudianteDTO>(resultado); 
        }

        // GET api/<EstudiantesController>/matricula/20210101
        [HttpGet("matricula/{matricula}")]
        public async Task<ActionResult<EstudianteDTO>> MatriculaGet(string matricula)
        {
            var resultado = await dbContexto.Estudiantes.FirstOrDefaultAsync(x => x.Matricula.Equals(matricula));
            var ResultadoMapeado = Mapeador.Map<EstudianteDTO>(resultado);

            if (ResultadoMapeado != null)
            {
                return ResultadoMapeado;
            }
            else
            {
                //return NoContent();
                return Ok("No hay resultados en la base de datos...");
            }
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
        public async Task<ActionResult> Put(int id, [FromBody] EstudianteEditarDTO estudiante)
        {
            if (estudiante.Id == id)
            {
                try
                {
                    var ModeloEstudiante = Mapeador.Map<EstudianteModelo>(estudiante);
                    dbContexto.Estudiantes.Update(ModeloEstudiante);
                    return Ok(await dbContexto.SaveChangesAsync());
                }
                catch (Exception Ex)
                {
                    return BadRequest("Ha ocurrido un error: " + Ex.Message);
                }
            }

            return BadRequest("Error el ID no coincide con el ID del objeto estudiante");
        }

        //
        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var EstudianteAEliminar = await dbContexto.Estudiantes.FindAsync(id);
                if (EstudianteAEliminar is not null)
                {
                    dbContexto.Estudiantes.Remove(EstudianteAEliminar);
                    return Ok(await dbContexto.SaveChangesAsync());
                }

                BadRequest("Id no existe en la BD");
            }


            return BadRequest("Id debe ser mayor de cero...");
        }

        //
        // DELETE api/<EstudiantesController>/5/softdelete
        [HttpDelete("{id}/sotfdelete")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            if (id > 0)
            {
                //var EstudianteAEliminar = await dbContexto.Estudiantes.FindAsync(id);
                //if (EstudianteAEliminar is not null)
                //{
                //    EstudianteAEliminar.EstaBorrado = true;
                //    dbContexto.Estudiantes.Update(EstudianteAEliminar);
                //    return Ok(await dbContexto.SaveChangesAsync());
                //}

                return Ok(await dbContexto.Estudiantes
                    .Where(e => e.Id == id)
                    .ExecuteUpdateAsync(e => e.SetProperty(d => d.EstaBorrado, true)));


            }

            return BadRequest("Id debe ser mayor de cero...");
        }

        //
        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{id}/recovery")]
        public async Task<ActionResult> RecoveryDelete(int id)
        {
            if (id > 0)
            {
                
                return Ok(await dbContexto.Estudiantes
                    .Where(e => e.Id == id)
                    .ExecuteUpdateAsync(e => e.SetProperty(d => d.EstaBorrado, false)));
            }

            return BadRequest("Id debe ser mayor de cero...");
        }
    }
}
