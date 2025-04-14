using SkillMatch.Domain.Entities;

namespace SkillMatch.Domain.Interfaces
{
    public interface IJobSkillRepository : IRepository<JobSkill>
    {
        Task<IReadOnlyList<JobSkill>> GetByJobPostingIdAsync(int jobPostingId);
        Task<IReadOnlyList<JobSkill>> GetBySkillIdAsync(int skillId);
    }
}