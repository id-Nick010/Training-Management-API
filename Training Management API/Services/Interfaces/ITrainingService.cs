using Training_Management_API.Models;

namespace Training_Management_API.Services.Interfaces
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingProgram>> GetAllTrainingsAsync();
        Task<TrainingProgram?> GetTrainingByIdAsync(int id);
        Task CreateTrainingAsync(TrainingProgram training);
        Task UpdateTrainingAsync(TrainingProgram training);
        Task DeleteTrainingAsync(int id);
    }
}
