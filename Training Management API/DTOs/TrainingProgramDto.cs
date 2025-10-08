namespace Training_Management_API.DTOs
{
    public class TrainingProgramDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TrainerId { get; set; }

        public string TrainerName { get; set; } = string.Empty;
        public List<string> ParticipantNames { get; set; } = new();
    }
}
