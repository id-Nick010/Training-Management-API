using Training_Management_API.Models;
using Training_Management_API.Repositories.Interfaces;
using Training_Management_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Training_Management_API.Repositories.Implementations
{
    public class TrainingRepository : Repository<TrainingProgram>, ITrainingRepository
    {
        public TrainingRepository(TrainingManagerDbContext context) : base(context) { }

        // Override from generic repository to include related entities
        public override async Task<IEnumerable<TrainingProgram>> GetAllAsync()
        {
            return await _context.Set<TrainingProgram>()
                .Include(tp => tp.Trainer)
                .Include(tp => tp.Participants)
                .ToListAsync();
        }
        public override async Task<TrainingProgram?> GetByIdAsync(int id)
        {
            return await _context.Set<TrainingProgram>()
                .Include(tp => tp.Trainer)
                .Include(tp => tp.Participants)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
