namespace SkillMatch.Domain.Entities
{
    public class JobSkill : BaseEntity
    {
        public int JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public string RequiredLevel { get; set; } // "Beginner", "Intermediate", "Advanced"
    }
}