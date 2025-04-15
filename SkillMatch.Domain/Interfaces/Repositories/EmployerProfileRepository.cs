using Microsoft.EntityFrameworkCore;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;
using SkillMatch.Infrastructure.Data;

namespace SkillMatch.Infrastructure.Repositories
{
    public class EmployerProfileRepository : Repository<EmployerProfile>, IEmployerProfileRepository
    {
        public EmployerProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<EmployerProfile> GetByUserIdAsync(int userId)
        {
            return await _dbContext.EmployerProfiles
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.UserId == userId);
        }

        public async Task<IReadOnlyList<EmployerProfile>> GetByCompanyNameAsync(string companyName)
        {
            return await _dbContext.EmployerProfiles
                .Include(e => e.User)
                .Where(e => e.CompanyName.Contains(companyName))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<EmployerProfile>> GetByIndustryAsync(string industry)
        {
            return await _dbContext.EmployerProfiles
                .Include(e => e.User)
                .Where(e => e.Industry.Contains(industry))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<EmployerProfile>> GetByLocationAsync(string location)
        {
            return await _dbContext.EmployerProfiles
                .Include(e => e.User)
                .Where(e => e.Location.Contains(location))
                .ToListAsync();
        }
    }
}