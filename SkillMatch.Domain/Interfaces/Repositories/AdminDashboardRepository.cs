using Microsoft.EntityFrameworkCore;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;
using SkillMatch.Infrastructure.Data;

namespace SkillMatch.Infrastructure.Repositories
{
    public class AdminDashboardRepository : Repository<AdminDashboard>, IAdminDashboardRepository
    {
        public AdminDashboardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<AdminDashboard> GetDashboardStatisticsAsync()
        {
            var dashboard = new AdminDashboard
            {
                TotalUsers = await _dbContext.Users.CountAsync(),
                TotalStudents = await _dbContext.Users.CountAsync(u => u.UserType == "Student"),
                TotalEmployers = await _dbContext.Users.CountAsync(u => u.UserType == "Employer"),
                TotalJobs = await _dbContext.JobPostings.CountAsync(),
                ActiveJobs = await _dbContext.JobPostings.CountAsync(j => j.Status == "Active" && j.Deadline > DateTime.UtcNow),
                TotalApplications = await _dbContext.JobApplications.CountAsync(),
                RecentUsers = await _dbContext.Users
                    .OrderByDescending(u => u.CreatedAt)
                    .Take(5)
                    .ToListAsync()
            };

            return dashboard;
        }

        public async Task<IReadOnlyList<JobPosting>> GetPendingApprovalJobsAsync()
        {
            return await _dbContext.JobPostings
                .Include(j => j.Employer)
                    .ThenInclude(e => e.User)
                .Where(j => j.Status == "Pending")
                .OrderByDescending(j => j.CreatedAt)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<User>> GetRecentlyRegisteredUsersAsync(int count)
        {
            return await _dbContext.Users
                .OrderByDescending(u => u.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetJobsByStatusCountAsync()
        {
            var statusCounts = await _dbContext.JobPostings
                .GroupBy(j => j.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Status, x => x.Count);

            return statusCounts;
        }

        public async Task<Dictionary<string, int>> GetUsersByTypeCountAsync()
        {
            var typeCounts = await _dbContext.Users
                .GroupBy(u => u.UserType)
                .Select(g => new { Type = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Type, x => x.Count);

            return typeCounts;
        }
    }
}