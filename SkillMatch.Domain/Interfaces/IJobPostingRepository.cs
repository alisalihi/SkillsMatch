using SkillMatch.Domain.Entities;

namespace SkillMatch.Domain.Interfaces
{
    public interface IJobPostingRepository : IRepository<JobPosting>
    {
        Task<IReadOnlyList<JobPosting>> GetByEmployerIdAsync(int employerId);
        Task<IReadOnlyList<JobPosting>> GetBySkillRequirementAsync(int skillId);
        Task<IReadOnlyList<JobPosting>> GetByLocationAsync(string location);
        Task<IReadOnlyList<JobPosting>> GetByStatusAsync(string status);
        Task<IReadOnlyList<JobPosting>> GetByPayRangeAsync(decimal minPay, decimal maxPay);
        Task<IReadOnlyList<JobPosting>> GetByDurationAsync(int minDuration, int maxDuration);
        Task<IReadOnlyList<JobPosting>> GetActiveJobsAsync();
        Task<IReadOnlyList<JobPosting>> GetRecommendedForStudentAsync(int studentId);
    }
}