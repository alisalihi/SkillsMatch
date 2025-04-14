using SkillMatch.Domain.Entities;

namespace SkillMatch.Domain.Interfaces
{
    public interface IStudentSkillRepository : IRepository<StudentSkill>
    {
        Task<IReadOnlyList<StudentSkill>> GetByStudentIdAsync(int studentId);
        Task<IReadOnlyList<StudentSkill>> GetBySkillIdAsync(int skillId);
        Task<StudentSkill> GetByStudentAndSkillAsync(int studentId, int skillId);
    }
}