namespace SkillMatch.Domain.Entities
{
    public class JobApplication : BaseEntity
    {
        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }
        public int JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }
        public string CoverLetter { get; set; }
        public string Status { get; set; } // "Pending", "Accepted", "Rejected", "Completed"
        public DateTime? AcceptedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}