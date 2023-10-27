using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Repositories;

namespace JaveragesLibrary.Services.Features.Mangas;

public class MangaService
{
    private readonly MangaRepository _mangaRepository;

    public MangaService(MangaRepository mangaRepository)
    {
        this._mangaRepository = mangaRepository;
    }

    public async Task<IEnumerable<Manga>> GetAll()
    {
        return await _mangaRepository.GetAll();
    }

    public async Task<Manga> GetById(int id)
    {
        return await _mangaRepository.GetById(id);
    }

    public async Task Add(Manga manga)
    {
        await _mangaRepository.Add(manga);
    }

    public async Task Update(Manga mangaToUpdate)
    {
        var manga = GetById(mangaToUpdate.Id);

        if (manga.Id > 0)
            await _mangaRepository.Update(mangaToUpdate);
    }

    public async Task Delete(int id)
    {
        var manga = GetById(id);

        if (manga.Id > 0)
            await _mangaRepository.Delete(id);
    }
}