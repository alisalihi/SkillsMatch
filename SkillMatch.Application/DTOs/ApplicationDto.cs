namespace SkillMatch.Application.DTOs
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int StudentId { get; set; }
        public string Status { get; set; } // e.g., Pending, Accepted, Rejected
        public DateTime AppliedAt { get; set; }
    }

    public class CreateApplicationDto
    {
        public int JobId { get; set; }
        public int StudentId { get; set; }
    }

    public class UpdateApplicationStatusDto
    {
        public string Status { get; set; }
    }
}
