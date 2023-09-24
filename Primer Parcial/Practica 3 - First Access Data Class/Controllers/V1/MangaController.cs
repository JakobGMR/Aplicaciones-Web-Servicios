using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Mangas;
using Microsoft.AspNetCore.Mvc;

namespace JaveragesLibrary.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class MangaController : ControllerBase
{
    private readonly MangaService _mangaService;

		public MangaController(MangaService mangaService)
    {
        this._mangaService = mangaService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_mangaService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var manga = _mangaService.GetById(id);
        if (manga == null)
            return NotFound();
        
        return Ok(manga);
    }

    [HttpPost]
    public IActionResult Add(Manga manga)
    {
        _mangaService.Add(manga);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Manga manga)
    {
        if (id != manga.Id)
            return BadRequest();

        _mangaService.Update(manga);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _mangaService.Delete(id);
        return NoContent();
    }
}