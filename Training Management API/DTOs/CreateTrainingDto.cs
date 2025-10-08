using System.ComponentModel.DataAnnotations;

namespace Training_Management_API.DTOs
{
    public class CreateTrainingDto
    {
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "TrainerId must be a positive number")]
        public int TrainerId { get; set; }
    }
}
