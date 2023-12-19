using AutoMapper;
using MatemApi.Domain.Dtos;
using MatemApi.Domain.Entities;
using MatemApi.Services.Features.Tutores;
using Microsoft.AspNetCore.Mvc;

namespace MatemApi.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class TutorController : ControllerBase
{
    private readonly TutorService _tutorService;
    private readonly IMapper _mapper;

    public TutorController(TutorService tutorService, IMapper mapper) {
        this._tutorService = tutorService;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var tutores = await _tutorService.GetAll();
        var tutorDtos = _mapper.Map<IEnumerable<TutorDto>>(tutores);

        return Ok(tutorDtos);
    }

    [HttpGet("{correo}")]
    public async Task<IActionResult> GetById(string correo) {
        var tutor = await _tutorService.GetById(correo);

        if(tutor.Correo == null)    return NotFound();

        var dto = _mapper.Map<TutorDto>(tutor);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(TutorCreateDto tutor) {
        var entity = _mapper.Map<Tutor>(tutor);

        await _tutorService.Add(entity);

        var dto = _mapper.Map<TutorDto>(entity);
        return CreatedAtAction(nameof(GetById), new {correo = entity.Correo}, dto);
    }

    [HttpPut("{correo}")]
    public async Task<IActionResult> Update(string correo, TutorCreateDto tutor) {
        if (correo != tutor.Correo) {
            return BadRequest();
        }

        var entity = _mapper.Map<Tutor>(tutor);
        await _tutorService.Update(entity);
        return NoContent();
    }

    [HttpDelete("{correo}")]
    public async Task<IActionResult> Delete(string correo) {
        await _tutorService.Delete(correo);
        return NoContent();
    }
}