using System.ComponentModel.DataAnnotations;

namespace Training_Management_API.Models
{
    public class TrainingProgram
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Relation
        // Foreign Key to relate TrainingProgram to Trainer
        public int TrainerId { get; set; }
        // Navigation property to access related data in Trainer
        public Trainer Trainer { get; set; }

        // One to Many relationship
        // Allows access to all participants in related to a training program
        public ICollection<Participant> Participants { get; set; }
    }
}
