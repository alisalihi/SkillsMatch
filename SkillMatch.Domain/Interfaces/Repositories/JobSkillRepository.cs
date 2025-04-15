using Microsoft.EntityFrameworkCore;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;
using SkillMatch.Infrastructure.Data;

namespace SkillMatch.Infrastructure.Repositories
{
    public class JobSkillRepository : Repository<JobSkill>, IJobSkillRepository
    {
        public JobSkillRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<JobSkill>> GetByJobPostingIdAsync(int jobPostingId)
        {
            return await _dbContext.JobSkills
                .Include(js => js.Skill)
                .Where(js => js.JobPostingId == jobPostingId)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<JobSkill>> GetBySkillIdAsync(int skillId)
        {
            return await _dbContext.JobSkills
                .Include(js => js.JobPosting)
                .Where(js => js.SkillId == skillId)
                .ToListAsync();
        }
    }
}