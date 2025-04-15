namespace SkillMatch.Domain.Entities
{
    public class EmployerProfile : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string WebsiteUrl { get; set; }

        // Navigation properties
        public List<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
    }
}