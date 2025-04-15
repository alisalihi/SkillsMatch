namespace SkillMatch.Domain.Entities
{
    public class StudentProfile : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string University { get; set; }
        public string FieldOfStudy { get; set; }
        public string Bio { get; set; }
        public int YearOfStudy { get; set; }
        public string Location { get; set; }

        // Navigation properties
        public List<StudentSkill> Skills { get; set; } = new List<StudentSkill>();
        public List<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}