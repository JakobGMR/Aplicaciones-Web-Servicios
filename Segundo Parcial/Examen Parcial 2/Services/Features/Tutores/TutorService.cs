using MatemApi.Domain.Entities;

namespace  MatemApi.Services.Features.Tutores;

public class TutorService
{
    private readonly TutorRepository _tutorRepository;

    public TutorService (TutorRepository tutorRepository) {
        this._tutorRepository = tutorRepository;
    }

    public async Task<IEnumerable<Tutor>> GetAll() {
        return await _tutorRepository.GetAll();
    }

    public async Task<Tutor> GetById(string correo) {
        return await _tutorRepository.GetById(correo);
    }

    public async Task Add(Tutor tutor) {
        await _tutorRepository.Add(tutor);
    }

    public async Task Update(Tutor tutorToUpdate) {
        var tutor = await GetById(tutorToUpdate.Correo!);

        if(tutor.Correo != null) {
            await _tutorRepository.Update(tutorToUpdate);
        }
    }

    public async Task Delete(string correo) {
        var tutor = await GetById(correo);

        if(tutor.Correo != null) {
            await _tutorRepository.Delete(correo);
        }
    }
}