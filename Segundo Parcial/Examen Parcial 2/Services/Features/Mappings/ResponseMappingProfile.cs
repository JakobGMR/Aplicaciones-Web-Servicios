using AutoMapper;
using MatemApi.Domain.Dtos;
using MatemApi.Domain.Entities;

namespace MatemApi.Services.Mappings;

public class ResponseMappingProfile : Profile
{
    public ResponseMappingProfile() {
        CreateMap<Alumno, AlumnoDto>()
            .ForMember(
                dest => dest.Tutor,
                opt => opt.MapFrom(src => src.IdTutorNavigation))
            .ForMember(
                dest => dest.Clase,
                opt => opt.MapFrom(src => src.IdClaseNavigation));
            
        CreateMap<Tutor, TutorDto>();

        CreateMap<Clase, ClaseDtoAll>();
        CreateMap<Clase, ClaseDto>()
            .ForMember(
                dest => dest.Alumnos,
                opt => opt.MapFrom(src => src.Alumno)
            );
        CreateMap<Alumno,AlumnoClaseDto>();
    }
}