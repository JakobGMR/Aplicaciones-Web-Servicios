using System.Text.Json;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JaveragesLibrary.Infrastructure.Repositories;

public class MangaRepository
{
    private List<Manga> _mangas;
    private string _filePath;
    private readonly JaveragesLibraryDbContext _context;
    

    public MangaRepository(JaveragesLibraryDbContext context)
    {
            this._context = context;
        
    }

    public async Task<IEnumerable<Manga>> GetAll()
    {
        var mangas = await _context.Mangas
                    .Include(manga => manga.Artists)
                    .ToListAsync();

        return mangas;
    }

    public async Task<Manga> GetById(int id)
    {
        var manga = await _context.Mangas.FirstOrDefaultAsync(manga => manga.Id == id);
        return manga ?? new Manga();
    }

    public async Task Add(Manga manga)
    {
        await _context.AddAsync(manga);
				await _context.SaveChangesAsync();
    }

    public async Task Update(Manga updatedManga)
    {
        var manga = await _context.Mangas.FirstOrDefaultAsync(manga => manga.Id == updatedManga.Id);

        if (manga != null)
        {
            _context.Entry(manga).CurrentValues.SetValues(updatedManga);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var manga = await _context.Mangas.FirstOrDefaultAsync(manga => manga.Id == id);
        if (manga != null)
        {
            _context.Mangas.Remove(manga);
            await _context.SaveChangesAsync();
        }
    }
}