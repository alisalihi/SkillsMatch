namespace SkillMatch.Domain.Entities
{
    public class JobPosting : BaseEntity
    {
        public int EmployerProfileId { get; set; }
        public EmployerProfile EmployerProfile { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal PayRate { get; set; }
        public string PayPeriod { get; set; } // "Hourly", "Fixed"
        public string Location { get; set; }
        public bool IsRemote { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int EstimatedHours { get; set; }
        public string Status { get; set; } // "Draft", "Active", "Filled", "Closed"
        public bool IsApproved { get; set; } = false;

        // Navigation properties
        public List<JobSkill> RequiredSkills { get; set; } = new List<JobSkill>();
        public List<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}