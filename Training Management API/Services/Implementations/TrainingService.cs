using Training_Management_API.Models;
using Training_Management_API.Repositories.Interfaces;
using Training_Management_API.Services.Interfaces;

namespace Training_Management_API.Services.Implementations
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepo;

        public TrainingService(ITrainingRepository trainingRepo)
        {
            _trainingRepo = trainingRepo;
        }

        // All service done by the repository
        public Task<IEnumerable<TrainingProgram>> GetAllTrainingsAsync()
            => _trainingRepo.GetAllAsync();

        public Task<TrainingProgram?> GetTrainingByIdAsync(int id)
            => _trainingRepo.GetByIdAsync(id);

        public Task CreateTrainingAsync(TrainingProgram training)
            => _trainingRepo.AddAsync(training);

        public Task UpdateTrainingAsync(TrainingProgram training)
            => _trainingRepo.UpdateAsync(training);

        public Task DeleteTrainingAsync(int id)
            => _trainingRepo.DeleteAsync(id);
    }
}
