using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;
using SoccerGame.Infrastructure.Data;

namespace SoccerGame.Infrastructure.Repositories;

public class JugadorRepository
{
    private readonly SoccerGameDbContext _context;
    public JugadorRepository(SoccerGameDbContext context)
    {
            this._context = context;
    }

    public async Task<IEnumerable<Jugador>> GetAll() {
        var usuarios = await _context.Jugadores
        .ToListAsync();

        return usuarios;
    }

    public async Task<Jugador> GetById(int id) {
        var jugador = await _context.Jugadores
                                    .FirstOrDefaultAsync(jugador => jugador.JugadorId == id);                                  
        return jugador ?? new Jugador();
    }

    public async Task<NombreEquipoDto> GetMaterias(int id) {
        var equipo = from j in _context.Jugadores
                     join t in _context.Teams on j.EquipoId equals t.EquipoId
                     where t.EquipoId == id
                     select new NombreEquipoDto {
                        NombreEquipo = t.NombreEquipo
                     };
        
        return (NombreEquipoDto)equipo;
    }

    public async Task Add(Jugador jugador) {
        await _context.AddAsync(jugador);    
        await _context.SaveChangesAsync();
    }

    public async Task Update(Jugador updatedJugador) {
        var jugador = await _context.Jugadores.FirstOrDefaultAsync(jugador => jugador.JugadorId == updatedJugador.JugadorId);

        if (jugador != null) {
            updatedJugador.JugadorId = jugador.JugadorId;
            _context.Entry(jugador).CurrentValues.SetValues(updatedJugador);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id) {
        var jugador = await GetById(id);

        if (jugador != null) {
            _context.Jugadores.Remove(jugador);
            await _context.SaveChangesAsync();
        }
    }
}