using System.ComponentModel.DataAnnotations;

namespace Training_Management_API.DTOs
{
    public class CreateTrainerDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        [StringLength(50)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        public string? Specialization { get; set; }
    }
}
