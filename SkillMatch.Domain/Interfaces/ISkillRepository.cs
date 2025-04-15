using SkillMatch.Domain.Entities;

namespace SkillMatch.Domain.Interfaces
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Task<Skill> GetByNameAsync(string name);
        Task<IReadOnlyList<Skill>> GetByCategoryAsync(string category);
        Task<IReadOnlyList<Skill>> GetByStudentIdAsync(int studentId);
    }
}