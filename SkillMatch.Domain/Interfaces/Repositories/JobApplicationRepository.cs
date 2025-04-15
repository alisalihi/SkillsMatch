using Microsoft.EntityFrameworkCore;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;
using SkillMatch.Infrastructure.Data;

namespace SkillMatch.Infrastructure.Repositories
{
    public class JobApplicationRepository : Repository<JobApplication>, IJobApplicationRepository
    {
        public JobApplicationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<JobApplication>> GetByStudentIdAsync(int studentId)
        {
            return await _dbContext.JobApplications
                .Include(a => a.StudentProfile)
                    .ThenInclude(s => s.User)
                .Include(a => a.JobPosting)
                    .ThenInclude(j => j.Employer)
                .Where(a => a.StudentProfileId == studentId)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<JobApplication>> GetByJobPostingIdAsync(int jobPostingId)
        {
            return await _dbContext.JobApplications
                .Include(a => a.StudentProfile)
                    .ThenInclude(s => s.User)
                .Include(a => a.JobPosting)
                .Where(a => a.JobPostingId == jobPostingId)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<JobApplication>> GetByStatusAsync(string status)
        {
            return await _dbContext.JobApplications
                .Include(a => a.StudentProfile)
                    .ThenInclude(s => s.User)
                .Include(a => a.JobPosting)
                    .ThenInclude(j => j.Employer)
                .Where(a => a.Status == status)
                .ToListAsync();
        }

        public async Task<JobApplication> GetByStudentAndJobPostingAsync(int studentId, int jobPostingId)
        {
            return await _dbContext.JobApplications
                .Include(a => a.StudentProfile)
                .Include(a => a.JobPosting)
                .FirstOrDefaultAsync(a => a.StudentProfileId == studentId && a.JobPostingId == jobPostingId);
        }

        public async Task<bool> ExistsForStudentAndJobAsync(int studentId, int jobPostingId)
        {
            return await _dbContext.JobApplications
                .AnyAsync(a => a.StudentProfileId == studentId && a.JobPostingId == jobPostingId);
        }
    }
}
