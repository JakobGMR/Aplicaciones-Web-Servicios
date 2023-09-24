using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Repositories;

namespace JaveragesLibrary.Services.Features.Mangas;

public class MangaService
{
    private readonly List<Manga> _mangas;
    private readonly MangaRepository _mangaRepository;

	// public MangaService()
    // {
    //     _mangas = new();
    // }

    // public IEnumerable<Manga> GetAll()
    // {
    //     return _mangas;
    // }

    // public Manga GetById(int id)
    // {
    //     return _mangas.FirstOrDefault(manga => manga.Id == id);
    // }

    // public void Add(Manga manga)
    // {
    //     _mangas.Add(manga);
    // }

    // public void Update(Manga mangaToUpdate)
    // {
    //     var manga = GetById(mangaToUpdate.Id);
    //     if (manga != null)
    //     {
    //         _mangas.Remove(manga);
    //         _mangas.Add(mangaToUpdate);
    //     }
    // }

    // public void Delete(int id)
    // {
    //     var manga = GetById(id);
    //     if (manga != null)
    //         _mangas.Remove(manga);
    // }

    // Manga Repository
    public MangaService(MangaRepository mangaRepository)
    {
        this._mangaRepository = mangaRepository;
    }

    public IEnumerable<Manga> GetAll()
    {
        return _mangaRepository.GetAll();
    }

    public Manga GetById(int id)
    {
        return _mangaRepository.GetById(id);
    }

    public void Add(Manga manga)
    {
        _mangaRepository.Add(manga);
    }

    public void Update(Manga mangaToUpdate)
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