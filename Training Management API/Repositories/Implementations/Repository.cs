using Microsoft.EntityFrameworkCore;
using Training_Management_API.Repositories.Interfaces;
using Training_Management_API.Data;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Training_Management_API.Repositories.Implementations
{
    // Main Repository class implementing generic CRUD operations
    // T is constrained to be a class (entity) can be Trainer, Participant, TrainingProgram, etc.
    // for custom behavior, derive from this class and override methods as needed
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TrainingManagerDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(TrainingManagerDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Basic CRUD operations to the database
        // Virtual methods to allow overriding in derived classes
        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public virtual async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
