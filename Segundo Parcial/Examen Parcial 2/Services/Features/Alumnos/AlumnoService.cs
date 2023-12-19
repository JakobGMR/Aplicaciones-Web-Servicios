using System.Collections;
using MatemApi.Domain.Entities;

namespace  MatemApi.Services.Features.Alumnos;

public class AlumnoService
{
    private readonly AlumnoRepository _alumnoRepository;

    public AlumnoService (AlumnoRepository alumnoRepository) {
        this._alumnoRepository = alumnoRepository;
    }

    public async Task<IEnumerable<Alumno>> GetAll() {
        return await _alumnoRepository.GetAll();
    }

    public async Task<Alumno> GetById(string correo) {
        return await _alumnoRepository.GetById(correo);
    }

    public async Task<ICollection<MateriaDto>> GetMaterias(string correo) {
        return await _alumnoRepository.GetMaterias(correo);
    }

    public async Task Add(Alumno alumno) {
        await _alumnoRepository.Add(alumno);
    }

    public async Task Update(Alumno alumnoToUpdate) {
        var alumno = await GetById(alumnoToUpdate.CorreoElectronico!);

        if(alumno.CorreoElectronico != null) {
            await _alumnoRepository.Update(alumnoToUpdate);
        }
    }

    public async Task Delete(string correo) {
        var alumno = await GetById(correo);

        if(alumno.CorreoElectronico != null) {
            await _alumnoRepository.Delete(correo);
        }
    }
}