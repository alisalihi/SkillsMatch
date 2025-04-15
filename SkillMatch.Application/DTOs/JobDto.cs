namespace SkillMatch.Application.DTOs
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal PayRate { get; set; }
        public string SkillRequired { get; set; }
        public int DurationInHours { get; set; }
        public int EmployerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsApproved { get; set; }
    }

    public class CreateJobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal PayRate { get; set; }
        public string SkillRequired { get; set; }
        public int DurationInHours { get; set; }
    }

    public class UpdateJobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal PayRate { get; set; }
        public string SkillRequired { get; set; }
        public int DurationInHours { get; set; }
        public bool IsApproved { get; set; }
    }
}
