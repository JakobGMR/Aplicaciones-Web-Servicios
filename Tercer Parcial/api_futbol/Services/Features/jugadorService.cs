using System.Collections;
using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;
using SoccerGame.Infrastructure.Repositories;

namespace SoccerGame.Services.Features;

public class JugadorService
{
    private readonly JugadorRepository _jugadorRepository;

    public JugadorService(JugadorRepository jugadorRepository) {
        this._jugadorRepository = jugadorRepository;
    }

    public async Task<IEnumerable<Jugador>> GetAll() {
        return await _jugadorRepository.GetAll();
    }

    public async Task<Jugador> GetById(int id) {
        return await _jugadorRepository.GetById(id);
    }

    public async Task<NombreEquipoDto> GetMaterias(int id) {
        return await _jugadorRepository.GetMaterias(id);
    }

    // public async Task<ICollection<MateriaDto>> GetMaterias(string correo) {
    //     return await _jugadorRepository.GetMaterias(correo);
    // }

    public async Task Add(Jugador jugador) {
        await _jugadorRepository.Add(jugador);
    }

    public async Task Update(Jugador jugadorToUpdate) {
        var jugador = await GetById(jugadorToUpdate.JugadorId);

        if(jugador.JugadorId != null) {
            await _jugadorRepository.Update(jugadorToUpdate);
        }
    }

    public async Task Delete(int id) {
        var jugador = await GetById(id);

        if(jugador.JugadorId != null) {
            await _jugadorRepository.Delete(id);
        }
    }
}