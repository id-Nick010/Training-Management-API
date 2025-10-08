using Training_Management_API.Models;

namespace Training_Management_API.Repositories.Interfaces
{
    public interface IParticipantRepository : IRepository<Participant>
    {
        Task<IEnumerable<Participant>> GetByTrainingProgramIdAsync(int trainingProgramId);
    }
}
