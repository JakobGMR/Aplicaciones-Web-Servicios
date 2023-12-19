using AutoMapper;
using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;

namespace SoccerGame.Services.Mappings;

public class ResponseMappingProfile : Profile
{
    public ResponseMappingProfile() {
        CreateMap<Jugador, JugadorDto>();
            // .ForMember(
                // dest => dest.Equipo,
                // opt => opt.MapFrom(src => src.Equipo.NombreEquipo));
            // .ForMember(
            //     dest => dest.Clase,
            //     opt => opt.MapFrom(src => src.IdClaseNavigation));
            
        CreateMap<Partido, PartidoDto>();
            

        // CreateMap<Clase, ClaseDtoAll>();
        CreateMap<Team, TeamDto>()
            .ForMember(
                dest => dest.Jugadores,
                opt => opt.MapFrom(src => src.Jugadores)
            );
    }
}