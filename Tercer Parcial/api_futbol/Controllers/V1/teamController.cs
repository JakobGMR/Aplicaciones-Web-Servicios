using AutoMapper;
using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;
using SoccerGame.Services.Features;
using Microsoft.AspNetCore.Mvc;

namespace SoccerGame.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly TeamService _teamService;
    private readonly IMapper _mapper;

    public TeamController(TeamService teamService, IMapper mapper) {
        this._teamService = teamService;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        try
        {
            var teames = await _teamService.GetAll();
            var teamesDto = _mapper.Map<IEnumerable<TeamDto>>(teames);
            teamesDto = teamesDto.ToList();

            foreach (var item in teamesDto)
            {
                item.Jugadores = await _teamService.GetJugadores(item.EquipoId);
            }

            return Ok(teamesDto);
        }
        catch (Exception error)
        {
            Console.WriteLine("Ocurrio un error: ", error);
            return BadRequest(2);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) {
        var team = await _teamService.GetById(id);

        if (team.EquipoId <= 0)     return NotFound();

        var dto = _mapper.Map<TeamDto>(team);
        dto.Jugadores = await _teamService.GetJugadores(dto.EquipoId);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(TeamCreateDto team) {
        try
        {
            var entity = _mapper.Map<Team>(team);
            await _teamService.Add(entity);

            var dto = _mapper.Map<TeamDto>(entity);
            
            // return CreatedAtAction("Nombre de la acción",dto);
            return CreatedAtAction(nameof(GetById), new {id = entity.EquipoId}, dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TeamCreateDto team) {
        if (id != team.EquipoId) {
            return BadRequest();
        }

        var entity = _mapper.Map<Team>(team);
        await _teamService.Update(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        await _teamService.Delete(id);
        return NoContent();
    }
}