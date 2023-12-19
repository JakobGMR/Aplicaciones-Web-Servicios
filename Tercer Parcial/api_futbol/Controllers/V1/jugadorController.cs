using AutoMapper;
using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;
using SoccerGame.Services.Features;
using Microsoft.AspNetCore.Mvc;

namespace SoccerGame.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class JugadorController : ControllerBase
{
    private readonly JugadorService _jugadorService;
    private readonly IMapper _mapper;

    public JugadorController(JugadorService jugadorService, IMapper mapper) {
        this._jugadorService = jugadorService;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        try
        {
            var jugadores = await _jugadorService.GetAll();
            var jugadoresDto = _mapper.Map<IEnumerable<JugadorDto>>(jugadores);
            jugadoresDto = jugadoresDto.ToList();

            return Ok(jugadoresDto);
        }
        catch (Exception error)
        {
            Console.WriteLine("Ocurrio un error: ", error);
            return BadRequest(2);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) {
        var jugador = await _jugadorService.GetById(id);

        if (jugador.JugadorId <= 0)     return NotFound();

        var dto = _mapper.Map<JugadorDto>(jugador);
        // dto.Equipo = await _jugadorService.GetMaterias(dto.JugadorId);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(JugadorCreateDto jugador) {
        try
        {
            var entity = _mapper.Map<Jugador>(jugador);
            await _jugadorService.Add(entity);

            var dto = _mapper.Map<JugadorDto>(entity);
            // return CreatedAtAction("Nombre de la acción",dto);
            return CreatedAtAction(nameof(GetById), new {id = entity.JugadorId}, dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, JugadorCreateDto jugador) {
        if (id != jugador.JugadorId) {
            return BadRequest();
        }

        var entity = _mapper.Map<Jugador>(jugador);
        await _jugadorService.Update(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        await _jugadorService.Delete(id);
        return NoContent();
    }
}