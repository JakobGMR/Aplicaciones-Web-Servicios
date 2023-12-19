using System.Collections;
using System.Linq;
using MatemApi.Domain.Entities;
using MatemApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class AlumnoRepository
{
    private readonly MatemApiDbContext _context;

    public AlumnoRepository(MatemApiDbContext context) {
        this._context = context;
    }

    public async Task<IEnumerable<Alumno>> GetAll() {
        var usuarios = await _context.Alumnos
        .Include(alumn => alumn.IdClaseNavigation)
        .Include(alumn => alumn.IdTutorNavigation)
        .ToListAsync();

        return usuarios;
    }

    public async Task<Alumno> GetById(string correo) {
        var alumno = await _context.Alumnos.Include(alumn => alumn.IdClaseNavigation)
                                           .Include(alumn => alumn.IdTutorNavigation)
                                           .FirstOrDefaultAsync(alumn => alumn.CorreoElectronico == correo);                                            
        return alumno ?? new Alumno();
    }

    public async Task<ICollection<MateriaDto>> GetMaterias(string correo) {
        var materias = from a in _context.Alumnos
                     join c in _context.Clases on a.IdClase equals c.IdClase
                     join ra in _context.RutaDeAprendizajes on c.IdClase equals ra.ClaseId
                     join m in _context.Materias on ra.MateriaId equals m.IdMateria
                     where a.CorreoElectronico == correo
                     select new MateriaDto {
                        Categoría = m.Categoría,
                        Nivel = m.Nivel,
                        Descripción = m.Descripción
                     };
        
        return await materias.ToListAsync();
    }

    public async Task Add(Alumno alumno) {
        await _context.AddAsync(alumno);    
        await _context.SaveChangesAsync();
    }

    public async Task Update(Alumno updatedAlumno) {
        var alumno = await _context.Alumnos.FirstOrDefaultAsync(alumno => alumno.CorreoElectronico == updatedAlumno.CorreoElectronico);

        if (alumno != null) {
            updatedAlumno.Id = alumno.Id;
            _context.Entry(alumno).CurrentValues.SetValues(updatedAlumno);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(string correo) {
        var alumno = await GetById(correo);

        if (alumno != null) {
            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();
        }
    }
}