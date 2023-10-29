using AutoMapper;
using TriviaBiblicoUNAD.Shared.DTOs.Estudiante;

namespace TriviaBiblicoUNAD.Client.Data
{
    public class AutoMaperClientePerfiles : Profile
    {
        public AutoMaperClientePerfiles()
        {
            CreateMap<EstudianteDTO, EstudianteEditarDTO>().ReverseMap();
        }
    }
}
