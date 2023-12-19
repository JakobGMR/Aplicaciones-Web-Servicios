using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;
using SoccerGame.Infrastructure.Data;

namespace SoccerGame.Infrastructure.Repositories;

public class PartidoRepository
{
    private readonly SoccerGameDbContext _context;
    public PartidoRepository(SoccerGameDbContext context)
    {
            this._context = context;
    }

    public async Task<IEnumerable<Partido>> GetAll() {
        var usuarios = await _context.Partidos
                        .Include(partido => partido.EquipoLocal)
                        .Include(alumno => alumno.EquipoVisitante)
        .ToListAsync();

        return usuarios;
    }

    public async Task<Partido> GetById(int id) {
        var partido = await _context.Partidos
                                    .Include(partido => partido.EquipoLocal)
                            .Include(alumno => alumno.EquipoVisitante)
                                    .FirstOrDefaultAsync(partido => partido.PartidoId == id);                                  
        return partido ?? new Partido();
    }

    public async Task<Team> GetTeam(int id) {
        var team = await _context.Teams.FirstOrDefaultAsync(tm => tm.EquipoId == id);

        return team ?? new Team();
    }

    public async Task<ICollection<JugadoresDto>> GetMaterias(int id) {
        var jugadores = from t in _context.Teams
                     join j in _context.Jugadores on t.EquipoId equals j.EquipoId
                     where j.EquipoId == id
                     select new JugadoresDto {
                        JugadorId = j.JugadorId,
                        NombreJugador = j.NombreJugador,
                        Posicion = j.Posicion,
                        Numero = j.Numero
                     };
        
        return await jugadores.ToListAsync();
    }

    // public async Task<ICollection<MateriaDto>> GetMaterias(string correo) {
    //     var materias = from a in _context.Partidos
    //                  join c in _context.Clases on a.IdClase equals c.IdClase
    //                  join ra in _context.RutaDeAprendizajes on c.IdClase equals ra.ClaseId
    //                  join m in _context.Materias on ra.MateriaId equals m.IdMateria
    //                  where a.CorreoElectronico == correo
    //                  select new MateriaDto {
    //                     Categoría = m.Categoría,
    //                     Nivel = m.Nivel,
    //                     Descripción = m.Descripción
    //                  };
        
    //     return await materias.ToListAsync();
    // }

    public async Task Add(Partido partido) {
        await _context.AddAsync(partido);    
        await _context.SaveChangesAsync();
    }

    public async Task Update(Partido updatedPartido) {
        var partido = await _context.Partidos.FirstOrDefaultAsync(partido => partido.PartidoId == updatedPartido.PartidoId);

        if (partido != null) {
            updatedPartido.PartidoId = partido.PartidoId;
            _context.Entry(partido).CurrentValues.SetValues(updatedPartido);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id) {
        var partido = await GetById(id);

        if (partido != null) {
            _context.Partidos.Remove(partido);
            await _context.SaveChangesAsync();
        }
    }
}