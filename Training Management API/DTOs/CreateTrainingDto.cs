using System.ComponentModel.DataAnnotations;

namespace Training_Management_API.DTOs
{
    public class CreateTrainingDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int TrainerId { get; set; }
    }
}
