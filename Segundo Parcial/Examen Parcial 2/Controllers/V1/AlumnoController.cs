using AutoMapper;
using MatemApi.Domain.Dtos;
using MatemApi.Domain.Entities;
using MatemApi.Services.Features.Alumnos;
using Microsoft.AspNetCore.Mvc;

namespace MatemApi.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class AlumnoController : ControllerBase
{
    private readonly AlumnoService _alumnoService;
    private readonly IMapper _mapper;

    public AlumnoController(AlumnoService alumnoService, IMapper mapper) {
        this._alumnoService = alumnoService;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var alumnos = await _alumnoService.GetAll();
        
        var alumnoDtos = _mapper.Map<IEnumerable<AlumnoDto>>(alumnos);
        alumnoDtos = alumnoDtos.ToList();
        
        foreach (var item in alumnoDtos)
        {
            item.Materias = await _alumnoService.GetMaterias(item.CorreoElectronico);
        }

        return Ok(alumnoDtos);
    }

    [HttpGet("{correo}")]
    public async Task<IActionResult> GetById(string correo) {
        var alumno = await _alumnoService.GetById(correo);

        if(alumno.CorreoElectronico == null)    return NotFound();

        var dto = _mapper.Map<AlumnoDto>(alumno);
        dto.Materias = await _alumnoService.GetMaterias(dto.CorreoElectronico);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AlumnoCreateDto alumno) {
        var entity = _mapper.Map<Alumno>(alumno);
        await _alumnoService.Add(entity);

        var dto = _mapper.Map<AlumnoDto>(entity);
        return CreatedAtAction(nameof(GetById), new {correo = entity.CorreoElectronico}, dto);
    }

    [HttpPut("{correo}")]
    public async Task<IActionResult> Update(string correo, AlumnoCreateDto alumno) {
        if (correo != alumno.CorreoElectronico) {
            return BadRequest();
        }

        var entity = _mapper.Map<Alumno>(alumno);
        await _alumnoService.Update(entity);
        return NoContent();
    }

    [HttpDelete("{correo}")]
    public async Task<IActionResult> Delete(string correo) {
        await _alumnoService.Delete(correo);
        return NoContent();
    }
}