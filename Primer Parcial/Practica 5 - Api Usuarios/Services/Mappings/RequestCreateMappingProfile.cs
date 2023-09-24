using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {
        CreateMap<UsuarioCreateDTO, Usuario>()
            .AfterMap
						(
                (src, dest) => 
                {
                    dest.PublicationDate = DateTime.Now;
                }
            );
    }
}