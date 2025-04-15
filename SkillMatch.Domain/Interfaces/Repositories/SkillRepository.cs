using Microsoft.EntityFrameworkCore;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;
using SkillMatch.Infrastructure.Data;

namespace SkillMatch.Infrastructure.Repositories
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Skill> GetByNameAsync(string name)
        {
            return await _dbContext.Skills
                .FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<IReadOnlyList<Skill>> GetByCategoryAsync(string category)
        {
            return await _dbContext.Skills
                .Where(s => s.Category == category)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Skill>> GetByStudentIdAsync(int studentId)
        {
            return await _dbContext.StudentSkills
                .Where(ss => ss.StudentProfileId == studentId)
                .Include(ss => ss.Skill)
                .Select(ss => ss.Skill)
                .ToListAsync();
        }
    }
}