using System.ComponentModel.DataAnnotations;

namespace Training_Management_API.Models
{
    public class Participant
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Department { get; set; }

        // Relation
        public int TrainingProgramId { get; set; }
        public TrainingProgram TrainingProgram { get; set; }
    }
}
