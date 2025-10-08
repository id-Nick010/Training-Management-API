using Training_Management_API.Models;

namespace Training_Management_API.Services.Interfaces
{
    public interface ITrainerService
    {
        Task<IEnumerable<Trainer>> GetAllTrainersAsync();
        Task<Trainer?> GetTrainerByIdAsync(int id);
        Task CreateTrainerAsync(Trainer trainer);
        Task UpdateTrainerAsync(Trainer trainer);
        Task DeleteTrainerAsync(int id);
    }
}
