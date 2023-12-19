using AutoMapper;
using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;
using SoccerGame.Services.Features;
using Microsoft.AspNetCore.Mvc;

namespace SoccerGame.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class PartidoController : ControllerBase
{
    private readonly PartidoService _partidoService;
    private readonly IMapper _mapper;

    public PartidoController(PartidoService partidoService, IMapper mapper) {
        this._partidoService = partidoService;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        try
        {
            var partidoes = await _partidoService.GetAll();
            
            var partidoesDto = _mapper.Map<IEnumerable<PartidoDto>>(partidoes);
            partidoesDto = partidoesDto.ToList();
            
            foreach (var item in partidoesDto)
            {
                var teamLocal = await _partidoService.GetTeam((int)item.EquipoLocalId);
                var teamLocalDto = _mapper.Map<Team, TeamDto>(teamLocal);
                teamLocalDto.Jugadores = await _partidoService.GetMaterias(teamLocalDto.EquipoId);
                var teamVisitante = await _partidoService.GetTeam((int)item.EquipoVisitanteId);
                var teamVisitanteDto = _mapper.Map<Team,TeamDto>(teamVisitante);
                teamVisitanteDto.Jugadores = await _partidoService.GetMaterias(teamVisitanteDto.EquipoId);

                item.EquipoLocal = teamLocalDto;
                item.EquipoVisitante = teamVisitanteDto;
            }

            return Ok(partidoesDto);
        }
        catch (Exception error)
        {
            Console.WriteLine("Ocurrio un error: ", error);
            return BadRequest(2);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) {
        var partido = await _partidoService.GetById(id);

        if (partido.PartidoId <= 0)     return NotFound();

        var dto = _mapper.Map<PartidoDto>(partido);

        var teamLocal = await _partidoService.GetTeam((int)dto.EquipoLocalId);
                var teamLocalDto = _mapper.Map<Team, TeamDto>(teamLocal);
                teamLocalDto.Jugadores = await _partidoService.GetMaterias(teamLocalDto.EquipoId);
                var teamVisitante = await _partidoService.GetTeam((int)dto.EquipoVisitanteId);
                var teamVisitanteDto = _mapper.Map<Team,TeamDto>(teamVisitante);
                teamVisitanteDto.Jugadores = await _partidoService.GetMaterias(teamVisitanteDto.EquipoId);

                dto.EquipoLocal = teamLocalDto;
                dto.EquipoVisitante = teamVisitanteDto;

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(PartidoCreateDto partido) {
        try
        {
            var entity = _mapper.Map<Partido>(partido);
            await _partidoService.Add(entity);

            var dto = _mapper.Map<PartidoDto>(entity);
            // return CreatedAtAction("Nombre de la acción",dto);
            return CreatedAtAction(nameof(GetById), new {id = entity.PartidoId}, dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PartidoCreateDto partido) {
        // if (id != partido.PartidoId) {
        //     return BadRequest();
        // }

        var entity = _mapper.Map<Partido>(partido);
        await _partidoService.Update(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        await _partidoService.Delete(id);
        return NoContent();
    }
}