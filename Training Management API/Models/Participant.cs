using System.ComponentModel.DataAnnotations;

namespace Training_Management_API.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Department { get; set; }

        // Relation
        // Foreign Key to relate Participant to TrainingProgram
        public int TrainingProgramId { get; set; }
        // Navigation property to access related data in TrainingProgram
        public TrainingProgram TrainingProgram { get; set; }
    }
}
