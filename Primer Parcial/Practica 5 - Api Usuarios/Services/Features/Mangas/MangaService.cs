using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Repositories;

namespace JaveragesLibrary.Services.Features.Mangas;

public class MangaService
{
    private readonly List<Usuario> _mangas;
    private readonly MangaRepository _mangaRepository;
    
    public MangaService(MangaRepository mangaRepository)
    {
        this._mangaRepository = mangaRepository;
    }

    public IEnumerable<Usuario> GetAll()
    {
        return _mangaRepository.GetAll();
    }

    public Usuario GetById(int id)
    {
        return _mangaRepository.GetById(id);
    }

    public void Add(Usuario manga)
    {
        _mangaRepository.Add(manga);
    }

    public void Update(Usuario mangaToUpdate)
    {
        var manga = GetById(mangaToUpdate.Id);

        if (manga.Id > 0)
            _mangaRepository.Update(mangaToUpdate);
    }

    public void Delete(int id)
    {
        var manga = GetById(id);
        if (manga.Id > 0)
            _mangaRepository.Delete(id);
    }
}