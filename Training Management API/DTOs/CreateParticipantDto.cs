using System.ComponentModel.DataAnnotations;

namespace Training_Management_API.DTOs
{
    public class CreateParticipantDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "TrainingProgramId must be a positive number")]
        public int TrainingProgramId { get; set; }
    }
}
