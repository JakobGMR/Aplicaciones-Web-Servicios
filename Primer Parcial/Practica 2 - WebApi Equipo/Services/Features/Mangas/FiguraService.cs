using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Services.Features.Mangas;

public class FiguraService
{
    private readonly List<Figura> _figuras;

	public FiguraService()
    {
        _figuras = new();
    }

    public IEnumerable<Figura> GetAll()
    {
        return _figuras;
    }

    public Figura GetById(int id)
    {
        return _figuras.FirstOrDefault(figura => figura.Id == id);
    }

    public void Add(Figura figura)
    {
        _figuras.Add(figura);
    }

    public void Update(Figura figuraToUpdate)
    {
        var figura = GetById(figuraToUpdate.Id);
        if (figura != null)
        {
            _figuras.Remove(figura);
            _figuras.Add(figuraToUpdate);
        }
    }

    public void Delete(int id)
    {
        var figura = GetById(id);
        if (figura != null)
            _figuras.Remove(figura);
    }
}