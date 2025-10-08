using Training_Management_API.Repositories.Implementations;
using Training_Management_API.Models;
using Training_Management_API.Repositories.Interfaces;
using Training_Management_API.Services.Interfaces;

namespace Training_Management_API.Services.Implementations
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepo;

        public ParticipantService(IParticipantRepository participantRepo)
        {
            _participantRepo = participantRepo;
        }

        public Task<IEnumerable<Participant>> GetAllParticipantsAsync()
            => _participantRepo.GetAllAsync();

        public Task<Participant?> GetParticipantByIdAsync(int id)
            => _participantRepo.GetByIdAsync(id);

        public Task<IEnumerable<Participant>> GetParticipantsByTrainingProgramIdAsync(int id)
            => _participantRepo.GetByTrainingProgramIdAsync(id);

        public Task CreateParticipantAsync(Participant participant)
            => _participantRepo.AddAsync(participant);

        public Task UpdateParticipantAsync(Participant participant)
            => _participantRepo.UpdateAsync(participant);

        public Task DeleteParticipantAsync(int id)
            => _participantRepo.DeleteAsync(id);
    }
}
