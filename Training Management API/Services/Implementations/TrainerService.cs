using Training_Management_API.Models;
using Training_Management_API.Repositories.Interfaces;
using Training_Management_API.Services.Interfaces;

namespace Training_Management_API.Services.Implementations
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepo;

        public TrainerService(ITrainerRepository trainerRepo)
        {
            _trainerRepo = trainerRepo;
        }


        // All basic CRUD operations just directed to the repository
        public Task<IEnumerable<Trainer>> GetAllTrainersAsync()
            => _trainerRepo.GetAllAsync();

        public Task<Trainer?> GetTrainerByIdAsync(int id)
            => _trainerRepo.GetByIdAsync(id);

        public Task CreateTrainerAsync(Trainer trainer)
            => _trainerRepo.AddAsync(trainer);

        public Task UpdateTrainerAsync(Trainer trainer)
            => _trainerRepo.UpdateAsync(trainer);

        public Task DeleteTrainerAsync(int id)
            => _trainerRepo.DeleteAsync(id);
    }
}
