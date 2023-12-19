using AutoMapper;
using MatemApi.Domain.Dtos;
using MatemApi.Domain.Entities;

namespace MatemApi.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile() {
        CreateMap<AlumnoCreateDto, Alumno>();
        CreateMap<TutorCreateDto, Tutor>();
        CreateMap<ClaseCreateDto, Clase>();
    }
}