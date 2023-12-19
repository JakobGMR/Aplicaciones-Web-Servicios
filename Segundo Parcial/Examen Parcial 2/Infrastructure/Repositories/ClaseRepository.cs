using MatemApi.Domain.Entities;
using MatemApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ClaseRepository
{
    private readonly MatemApiDbContext _context;

    public ClaseRepository(MatemApiDbContext context) {
        this._context = context;
    }

    public async Task<IEnumerable<Clase>> GetAll() {
        var clases = await _context.Clases.ToListAsync();
        return clases;
    }

    public async Task<Clase> GetById(int grado, string grupo) {
        var clase = await _context.Clases
                          .Include(clas => clas.Alumno)
                          .FirstOrDefaultAsync(clas =>
                                clas.Grado == grado && clas.Grupo == grupo
                            );
        return clase ?? new Clase();
    }

    // public async Task<Clase> GetById(int id) {
    //     var clase = await _context.Clases.FirstOrDefaultAsync(clas => clas.IdClase == id);
    //     return clase ?? new Clase();
    // }

    public async Task Add(Clase clase) {
        await _context.AddAsync(clase);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Clase updatedClase) {
        var clase = GetById(updatedClase.IdClase, updatedClase.Grupo);

        if (clase != null) {
            _context.Entry(clase).CurrentValues.SetValues(updatedClase);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int grado, string grupo) {
        var clase = await GetById(grado,grupo);

        if (clase != null) {
            _context.Clases.Remove(clase);
            await _context.SaveChangesAsync();
        }
    }
}