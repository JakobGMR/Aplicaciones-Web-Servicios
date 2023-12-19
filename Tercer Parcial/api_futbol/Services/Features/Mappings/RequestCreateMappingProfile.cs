using AutoMapper;
using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;

namespace SoccerGame.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile() {
        CreateMap<PartidoCreateDto, Partido>();
        CreateMap<JugadorCreateDto, Jugador>();
        CreateMap<TeamCreateDto, Team>();
    }
}