using System.Collections;
using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;
using SoccerGame.Infrastructure.Repositories;

namespace SoccerGame.Services.Features;

public class PartidoService
{
    private readonly PartidoRepository _partidoRepository;

    public PartidoService(PartidoRepository partidoRepository) {
        this._partidoRepository = partidoRepository;
    }

    public async Task<IEnumerable<Partido>> GetAll() {
        return await _partidoRepository.GetAll();
    }

    public async Task<Partido> GetById(int id) {
        return await _partidoRepository.GetById(id);
    }

        public async Task<Team> GetTeam(int id) {
            return await _partidoRepository.GetTeam(id);
        }

    public async Task<ICollection<JugadoresDto>> GetMaterias(int id) {
        return await _partidoRepository.GetMaterias(id);
    }

    public async Task Add(Partido partido) {
        await _partidoRepository.Add(partido);
    }

    public async Task Update(Partido partidoToUpdate) {
        var partido = await GetById(partidoToUpdate.PartidoId);

        if(partido.PartidoId != null) {
            await _partidoRepository.Update(partidoToUpdate);
        }
    }

    public async Task Delete(int id) {
        var partido = await GetById(id);

        if(partido.PartidoId != null) {
            await _partidoRepository.Delete(id);
        }
    }
}