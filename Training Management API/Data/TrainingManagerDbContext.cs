namespace Training_Management_API.Data
{
    using Microsoft.EntityFrameworkCore;
    using Training_Management_API.Models;


    public class TrainingManagerDbContext : DbContext
    {
        public TrainingManagerDbContext(DbContextOptions<TrainingManagerDbContext> options) : base(options) { }

        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
