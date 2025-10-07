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
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        // Navigation
        public ICollection<Participant> Participants { get; set; }
    }
}
