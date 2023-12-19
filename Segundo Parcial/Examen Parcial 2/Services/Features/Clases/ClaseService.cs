using System.Collections;
using MatemApi.Domain.Entities;
using MatemApi.Infrastructure;

namespace  MatemApi.Services.Features.Clases;

public class ClaseService
{
    private readonly ClaseRepository _claseRepository;

    public ClaseService (ClaseRepository claseRepository) {
        this._claseRepository = claseRepository;
    }

    public async Task<IEnumerable<Clase>> GetAll() {
        return await _claseRepository.GetAll();
    }

    public async Task<Clase> GetById(int grado, string grupo) {
        return await _claseRepository.GetById(grado, grupo);
    }

    // public async Task<ICollection<MateriaDto>> GetMaterias(int correo) {
    //     return await _claseRepository.GetMaterias(correo);
    // }

    public async Task Add(Clase clase) {
        await _claseRepository.Add(clase);
    }

    public async Task Update(Clase claseToUpdate) {
        var clase = await GetById(claseToUpdate.Grado, claseToUpdate.Grupo);

        if(clase.IdClase > 0) {
            await _claseRepository.Update(claseToUpdate);
        }
    }

    public async Task Delete(int grado, string grupo) {
        var clase = await GetById(grado, grupo);

        if(clase.IdClase > 0) {
            await _claseRepository.Delete(grado, grupo);
        }
    }
}