using System.ComponentModel.DataAnnotations;

namespace Training_Management_API.DTOs
{
    public class CreateParticipantDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        [Required]
        public int TrainingProgramId { get; set; }
    }
}
