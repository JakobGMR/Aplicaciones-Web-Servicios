using MatemApi.Domain.Entities;
using MatemApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class TutorRepository
{
    private readonly MatemApiDbContext _context;

    public TutorRepository(MatemApiDbContext context) {
        this._context = context;
    }

    public async Task<IEnumerable<Tutor>> GetAll() {
        var tutores = await _context.Tutores
                      .Include(tutor => tutor.Alumnos)
                      .ToListAsync();
        return tutores;
    }

    public async Task<Tutor> GetById(string correo) {
        var tutor = await _context.Tutores
                    .Include(tutor => tutor.Alumnos)
                    .FirstOrDefaultAsync(tuto => tuto.Correo == correo);
        return tutor ?? new Tutor();
    }

    public async Task Add(Tutor tutor) {
        await _context.AddAsync(tutor);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Tutor updatedTutor) {
        var tutor = GetById(updatedTutor.Correo!);

        if (tutor != null) {
            _context.Entry(tutor).CurrentValues.SetValues(updatedTutor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(string correo) {
        var tutor = await GetById(correo);

        if (tutor != null) {
            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();
        }
    }
}