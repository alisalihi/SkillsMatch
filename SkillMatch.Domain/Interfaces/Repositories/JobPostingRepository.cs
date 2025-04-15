using Microsoft.EntityFrameworkCore;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;
using SkillMatch.Infrastructure.Data;

namespace SkillMatch.Infrastructure.Repositories
{
    public class JobPostingRepository : Repository<JobPosting>, IJobPostingRepository
    {
        public JobPostingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<JobPosting>> GetByEmployerIdAsync(int employerId)
        {
            return await _dbContext.JobPostings
                .Include(j => j.Employer)
                .Include(j => j.JobSkills)
                    .ThenInclude(js => js.Skill)
                .Where(j => j.EmployerId == employerId)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<JobPosting>> GetBySkillRequirementAsync(int skillId)
        {
            return await _dbContext.JobPostings
                .Include(j => j.Employer)
                .Include(j => j.JobSkills)
                    .ThenInclude(js => js.Skill)
                .Where(j => j.JobSkills.Any(js => js.SkillId == skillId))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<JobPosting>> GetByLocationAsync(string location)
        {
            return await _dbContext.JobPostings
                .Include(j => j.Employer)
                .Where(j => j.Location.Contains(location))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<JobPosting>> GetByStatusAsync(string status)
        {
            return await _dbContext.JobPostings
                .Include(j => j.Employer)
                .Where(j => j.Status == status)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<JobPosting>> GetByPayRangeAsync(decimal minPay, decimal maxPay)
        {
            return await _dbContext.JobPostings
                .Include(j => j.Employer)
                .Where(j => j.PayRate >= minPay && j.PayRate <= maxPay)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<JobPosting>> GetByDurationAsync(int minDuration, int maxDuration)
        {
            return await _dbContext.JobPostings
                .Include(j => j.Employer)
                .Where(j => j.DurationInHours >= minDuration && j.DurationInHours <= maxDuration)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<JobPosting>> GetActiveJobsAsync()
        {
            return await _dbContext.JobPostings
                .Include(j => j.Employer)
                .Include(j => j.JobSkills)
                    .ThenInclude(js => js.Skill)
                .Where(j => j.Status == "Active" && j.Deadline > DateTime.UtcNow)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<JobPosting>> GetRecommendedForStudentAsync(int studentId)
        {
            // Get student skills
            var studentSkills = await _dbContext.StudentSkills
                .Where(ss => ss.StudentProfileId == studentId)
                .Select(ss => ss.SkillId)
                .ToListAsync();

            // Get student profile for location matching
            var studentProfile = await _dbContext.StudentProfiles
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (studentProfile == null)
                return new List<JobPosting>();

            // Find jobs with matching skills and/or location
            return await _dbContext.JobPostings
                .Include(j => j.Employer)
                .Include(j => j.JobSkills)
                    .ThenInclude(js => js.Skill)
                .Where(j => j.Status == "Active"
                    && j.Deadline > DateTime.UtcNow
                    && (j.JobSkills.Any(js => studentSkills.Contains(js.SkillId))
                        || j.Location.Contains(studentProfile.Location)))
                .OrderByDescending(j => j.JobSkills.Count(js => studentSkills.Contains(js.SkillId)))
                .ThenBy(j => j.Location == studentProfile.Location ? 0 : 1)
                .ToListAsync();
        }
    }
}