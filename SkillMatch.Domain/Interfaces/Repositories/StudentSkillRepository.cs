using Microsoft.EntityFrameworkCore;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;
using SkillMatch.Infrastructure.Data;

namespace SkillMatch.Infrastructure.Repositories
{
    public class StudentSkillRepository : Repository<StudentSkill>, IStudentSkillRepository
    {
        public StudentSkillRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<StudentSkill>> GetByStudentIdAsync(int studentId)
        {
            return await _dbContext.StudentSkills
                .Include(ss => ss.Skill)
                .Where(ss => ss.StudentProfileId == studentId)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<StudentSkill>> GetBySkillIdAsync(int skillId)
        {
            return await _dbContext.StudentSkills
                .Include(ss => ss.StudentProfile)
                .Where(ss => ss.SkillId == skillId)
                .ToListAsync();
        }

        public async Task<StudentSkill> GetByStudentAndSkillAsync(int studentId, int skillId)
        {
            return await _dbContext.StudentSkills
                .FirstOrDefaultAsync(ss => ss.StudentProfileId == studentId && ss.SkillId == skillId);
        }
    }
}