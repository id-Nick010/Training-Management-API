using Training_Management_API.Data;
using Training_Management_API.Models;
using Training_Management_API.Repositories.Interfaces;

namespace Training_Management_API.Repositories.Implementations
{
    public class TrainerRepository : Repository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(TrainingManagerDbContext context) : base(context) { }
    }
}
