using System.Text.Json;
using JaveragesLibrary.Domain.Entities;
namespace JaveragesLibrary.Infrastructure.Repositories;

public class MangaRepository
{
    private List<Usuario> _mangas;
    private readonly string _filePath;

    public MangaRepository(IConfiguration configuration)
    {
        _filePath = configuration.GetValue<string>("dataBank") ?? string.Empty;
        _mangas = LoadData();
    }

    private string GetCurrentFilePath()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var currentFilePath = Path.Combine(currentDirectory, _filePath);

        return currentFilePath;
    }
    private List<Usuario> LoadData()
    {
        var currentFilePath = GetCurrentFilePath();

        if (File.Exists(currentFilePath))
        {
            var jsonData = File.ReadAllText(currentFilePath);
            return JsonSerializer.Deserialize<List<Usuario>>(jsonData)!;
        }

        return new List<Usuario>();
    }

    public IEnumerable<Usuario> GetAll()
    {
        return _mangas;
    }

    public Usuario GetById(int id)
    {
        return _mangas.FirstOrDefault(manga => manga.Id == id)
                ?? new Usuario
                {
                    Name = string.Empty,
                    Lastname = string.Empty,
                    Age = string.Empty,
                    Email = string.Empty,
                    Password = string.Empty
                };
    }

    public void Add(Usuario manga)
    {
        var currentFilePath = GetCurrentFilePath();
        if (!File.Exists(currentFilePath))
            return;
            
        _mangas.Add(manga);
        File.WriteAllText(_filePath, JsonSerializer.Serialize(_mangas));
    }

    public void Update(Usuario updatedManga)
    {
        var currentFilePath = GetCurrentFilePath();
        if (!File.Exists(currentFilePath))
            return;

        var index = _mangas.FindIndex(m => m.Id == updatedManga.Id);

        if (index != -1)
        {
            _mangas[index] = updatedManga;
            File.WriteAllText(_filePath, JsonSerializer.Serialize(_mangas));
        }
    }

    public void Delete(int id)
    {
        var currentFilePath = GetCurrentFilePath();
        if (!File.Exists(currentFilePath))
            return;

        _mangas.RemoveAll(m => m.Id == id);
        File.WriteAllText(_filePath, JsonSerializer.Serialize(_mangas));
    }
}