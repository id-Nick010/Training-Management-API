using Training_Management_API.Models;

namespace Training_Management_API.Services.Interfaces
{
    public interface IParticipantService
    {
        Task<IEnumerable<Participant>> GetAllParticipantsAsync();
        Task<Participant?> GetParticipantByIdAsync(int id);
        Task<IEnumerable<Participant>> GetParticipantsByTrainingProgramIdAsync(int trainingProgramId);
        Task CreateParticipantAsync(Participant participant);
        Task UpdateParticipantAsync(Participant participant);
        Task DeleteParticipantAsync(int id);
    }
}
