namespace SkillMatch.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }

        // Navigation properties
        public List<StudentSkill> StudentSkills { get; set; } = new List<StudentSkill>();
        public List<JobSkill> JobSkills { get; set; } = new List<JobSkill>();
    }
}