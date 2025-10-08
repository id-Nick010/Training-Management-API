using Training_Management_API.Data;
using Training_Management_API.Models;
using Training_Management_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Training_Management_API.Repositories.Implementations
{
    public class ParticipantRepository : Repository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(TrainingManagerDbContext context) : base(context){ }

        public async Task<IEnumerable<Participant>> GetByTrainingProgramIdAsync(int trainingProgramId)
        {
            return await _dbSet
                .Where(p => p.TrainingProgramId == trainingProgramId)
                .ToListAsync();
        }
    }
}
