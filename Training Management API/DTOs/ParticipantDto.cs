namespace Training_Management_API.DTOs
{
    public class ParticipantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int TrainingProgramId { get; set; }
        public string TrainingTitle { get; set; } = string.Empty;
    }
}
