using Microsoft.EntityFrameworkCore;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;
using SkillMatch.Infrastructure.Data;

namespace SkillMatch.Infrastructure.Repositories
{
    public class StudentProfileRepository : Repository<StudentProfile>, IStudentProfileRepository
    {
        public StudentProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<StudentProfile> GetByUserIdAsync(int userId)
        {
            return await _dbContext.StudentProfiles
                .Include(s => s.User)
                .Include(s => s.StudentSkills)
                    .ThenInclude(ss => ss.Skill)
                .FirstOrDefaultAsync(s => s.UserId == userId);
        }

        public async Task<IReadOnlyList<StudentProfile>> GetBySkillAsync(int skillId)
        {
            return await _dbContext.StudentProfiles
                .Include(s => s.User)
                .Include(s => s.StudentSkills)
                .Where(s => s.StudentSkills.Any(ss => ss.SkillId == skillId))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<StudentProfile>> GetByLocationAsync(string location)
        {
            return await _dbContext.StudentProfiles
                .Include(s => s.User)
                .Where(s => s.Location.Contains(location))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<StudentProfile>> GetByAvailabilityAsync(bool isAvailable)
        {
            return await _dbContext.StudentProfiles
                .Include(s => s.User)
                .Where(s => s.IsAvailable == isAvailable)
                .ToListAsync();
        }
    }
}