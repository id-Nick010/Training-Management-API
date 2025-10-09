using Training_Management_API.Data;
using Training_Management_API.Models;
using Training_Management_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Training_Management_API.Repositories.Implementations
{
    public class ParticipantRepository : Repository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(TrainingManagerDbContext context) : base(context){ }

        // Override from generic repository to include related entities
        public override async Task<IEnumerable<Participant>> GetAllAsync()
        {
            return await _context.Set<Participant>()
                .Include(p => p.TrainingProgram)
                .ToListAsync();
        }

        // by Id with related entities included
        public override async Task<Participant?> GetByIdAsync(int id)
        {
            return await _context.Set<Participant>()
                .Include(p => p.TrainingProgram)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // custom method to get participants by training program ID
        public async Task<IEnumerable<Participant>> GetByTrainingProgramIdAsync(int trainingProgramId)
        {
            return await _context.Participants
                .Where(p => p.TrainingProgramId == trainingProgramId)
                .ToListAsync();
        }
    }
}
