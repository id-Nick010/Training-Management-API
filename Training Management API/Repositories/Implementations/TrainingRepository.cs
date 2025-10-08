using Training_Management_API.Models;
using Training_Management_API.Repositories.Interfaces;
using Training_Management_API.Data;

namespace Training_Management_API.Repositories.Implementations
{
    public class TrainingRepository : Repository<TrainingProgram>, ITrainingRepository
    {
        public TrainingRepository(TrainingManagerDbContext context) : base(context) { }
    }
}
