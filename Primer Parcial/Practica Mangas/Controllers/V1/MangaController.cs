using Microsoft.AspNetCore.Mvc;

using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Mangas;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;

namespace JaveragesLibrary.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class MangaController : ControllerBase
{
    private readonly MangaService _mangaService;
    private readonly IMapper _mapper;

    public MangaController(MangaService mangaService, IMapper mapper)
    {
        this._mangaService = mangaService;
        this._mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var mangas = await _mangaService.GetAll();
        var mangaDtos = _mapper.Map<IEnumerable<MangaDTO>>(mangas); 
        
        return Ok(mangaDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var manga = await _mangaService.GetById(id);

        if (manga.Id <= 0)
            return NotFound();

        var dto = _mapper.Map<MangaDTO>(manga); 

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(MangaCreateDTO manga)
    {
        var entity = _mapper.Map<Manga>(manga);

        await _mangaService.Add(entity);

        var dto = _mapper.Map<MangaDTO>(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Manga manga)
    {
        if (id != manga.Id)
        {
            return BadRequest();
        }

        await _mangaService.Update(manga);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mangaService.Delete(id);
        return NoContent();
    }
}