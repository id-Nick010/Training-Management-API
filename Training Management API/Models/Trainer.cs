using System.ComponentModel.DataAnnotations;

namespace Training_Management_API.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Specialization { get; set; }

        //Reverse Navigation
        // A trainer can conduct multiple training programs
        // One is to Many relationship
        public ICollection<TrainingProgram>  TrainingPrograms { get; set; }
    }
}
