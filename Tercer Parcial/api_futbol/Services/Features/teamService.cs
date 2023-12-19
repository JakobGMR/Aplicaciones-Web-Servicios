using System.Collections;
using SoccerGame.Domain.Dtos;
using SoccerGame.Domain.Entities;
using SoccerGame.Infrastructure.Repositories;

namespace SoccerGame.Services.Features;

public class TeamService
{
    private readonly TeamRepository _teamRepository;

    public TeamService(TeamRepository teamRepository) {
        this._teamRepository = teamRepository;
    }

    public async Task<IEnumerable<Team>> GetAll() {
        return await _teamRepository.GetAll();
    }

    public async Task<Team> GetById(int id) {
        return await _teamRepository.GetById(id);
    }


    // public async Task<ICollection<MateriaDto>> GetMaterias(string correo) {
    //     return await _teamRepository.GetMaterias(correo);
    // }

    public async Task Add(Team team) {
        await _teamRepository.Add(team);
    }

    public async Task Update(Team teamToUpdate) {
        var team = await GetById(teamToUpdate.EquipoId);

        if(team.EquipoId != null) {
            await _teamRepository.Update(teamToUpdate);
        }
    }

    public async Task<ICollection<JugadoresDto>> GetJugadores(int id) {
        return await _teamRepository.GetMaterias(id);
    }

    public async Task Delete(int id) {
        var team = await GetById(id);

        if(team.EquipoId != null) {
            await _teamRepository.Delete(id);
        }
    }
}