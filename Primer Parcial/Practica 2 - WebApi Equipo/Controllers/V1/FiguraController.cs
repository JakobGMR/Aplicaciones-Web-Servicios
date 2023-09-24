using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Mangas;
using Microsoft.AspNetCore.Mvc;

namespace JaveragesLibrary.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class FiguraController : ControllerBase
{
    private readonly FiguraService _figuraService;

		public FiguraController(FiguraService figuraService)
    {
        this._figuraService = figuraService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_figuraService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var figura = _figuraService.GetById(id);
        if (figura == null)
            return NotFound();
        
        return Ok(figura);
    }

    [HttpPost]
    public IActionResult Add(Figura figura)
    {
        _figuraService.Add(figura);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Figura figura)
    {
        if (id != figura.Id)
            return BadRequest();

        _figuraService.Update(figura);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _figuraService.Delete(id);
        return NoContent();
    }
}