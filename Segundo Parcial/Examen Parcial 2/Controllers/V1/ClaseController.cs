using AutoMapper;
using MatemApi.Domain.Dtos;
using MatemApi.Domain.Entities;
using MatemApi.Services.Features.Clases;
using Microsoft.AspNetCore.Mvc;

namespace MatemApi.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class ClaseController : ControllerBase
{
    private readonly ClaseService _claseService;
    private readonly IMapper _mapper;

    public ClaseController(ClaseService claseService, IMapper mapper) {
        this._claseService = claseService;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        try
        {
            var clases = await _claseService.GetAll();
            var clasesDto = _mapper.Map<IEnumerable<ClaseDtoAll>>(clases);
            clasesDto = clasesDto.ToList();

            return Ok(clasesDto);
        }
        catch (Exception error)
        {
            Console.WriteLine("Ocurrio un error: ", error);
            return BadRequest(2);
        }
    }

    [HttpGet("{grado}/{grupo}")]
    public async Task<IActionResult> GetById(int grado, string grupo) {
        var clase = await _claseService.GetById(grado, grupo);

        if (clase.IdClase <= 0)     return NotFound();

        var dto = _mapper.Map<ClaseDto>(clase);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ClaseCreateDto clase) {
        try
        {
            var entity = _mapper.Map<Clase>(clase);
            await _claseService.Add(entity);

            var dto = _mapper.Map<ClaseDto>(entity);
            // return CreatedAtAction("Nombre de la acción",dto);
            return CreatedAtAction(nameof(GetById), new {id = entity.IdClase}, dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e);
        }
    }
}