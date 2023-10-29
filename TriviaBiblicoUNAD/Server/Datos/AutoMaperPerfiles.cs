using AutoMapper;
using TriviaBiblicoUNAD.Server.Modelos.Estudiantes;
using TriviaBiblicoUNAD.Shared.DTOs.Estudiante;

namespace TriviaBiblicoUNAD.Server.Datos
{
    public class AutoMaperPerfiles : Profile
    {
        public AutoMaperPerfiles()
        {
            //Perfile de proyecciones de MODELOS -> DTO -> MODELOS
            //CreateMap<F,D>()
            CreateMap<EstudianteModelo, EstudianteDTO>().ReverseMap();
            CreateMap<EstudianteInsertarDTO, EstudianteModelo>();
            CreateMap<EstudianteEditarDTO, EstudianteModelo>();            
        }
    }
}
