using Training_Management_API.Models;
using Training_Management_API.Repositories.Interfaces;
using Training_Management_API.Data;

namespace Training_Management_API.Repositories.Implementations
{
    public class TrainingProgramRepository : Repository<TrainingProgram>, ITrainingProgramRepository
    {
        public TrainingProgramRepository(TrainingManagerDbContext context) : base(context) { }
    }
}
