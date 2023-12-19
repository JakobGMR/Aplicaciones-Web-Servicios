using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;
using SoccerGame.Infrastructure.Data;

namespace SoccerGame.Infrastructure.Repositories;

public class TeamRepository
{
    private readonly SoccerGameDbContext _context;
    public TeamRepository(SoccerGameDbContext context)
    {
            this._context = context;
    }

    public async Task<IEnumerable<Team>> GetAll() {
        var usuarios = await _context.Teams
        .ToListAsync();

        return usuarios;
    }

    public async Task<Team> GetById(int id) {
        var team = await _context.Teams
                                    .FirstOrDefaultAsync(team => team.EquipoId == id);                                  
        return team ?? new Team();
    }

    public async Task<ICollection<JugadoresDto>> GetMaterias(int id) {
        var jugadores = from t in _context.Teams
                     join j in _context.Jugadores on t.EquipoId equals j.EquipoId
                     where j.EquipoId == id
                     select new JugadoresDto {
                        JugadorId = j.JugadorId,
                        NombreJugador = j.NombreJugador,
                        Numero = j.Numero,
                        Posicion = j.Posicion
                     };
        
        return await jugadores.ToListAsync();
    }

    public async Task Add(Team team) {
        await _context.AddAsync(team);    
        await _context.SaveChangesAsync();
    }

    public async Task Update(Team updatedTeam) {
        var team = await _context.Teams.FirstOrDefaultAsync(team => team.EquipoId == updatedTeam.EquipoId);

        if (team != null) {
            updatedTeam.EquipoId = team.EquipoId;
            _context.Entry(team).CurrentValues.SetValues(updatedTeam);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id) {
        var team = await GetById(id);

        if (team != null) {
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
        }
    }
}