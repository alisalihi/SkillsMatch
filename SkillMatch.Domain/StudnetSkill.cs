namespace SkillMatch.Domain.Entities
{
    public class StudentSkill : BaseEntity
    {
        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public string ProficiencyLevel { get; set; } // "Beginner", "Intermediate", "Advanced"
    }
}