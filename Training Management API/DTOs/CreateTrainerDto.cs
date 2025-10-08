using System.ComponentModel.DataAnnotations;

namespace Training_Management_API.DTOs
{
    public class CreateTrainerDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Specialization { get; set; }
    }
}
