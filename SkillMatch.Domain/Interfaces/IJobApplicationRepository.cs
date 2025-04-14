using SkillMatch.Domain.Entities;

namespace SkillMatch.Domain.Interfaces
{
    public interface IJobApplicationRepository : IRepository<JobApplication>
    {
        Task<IReadOnlyList<JobApplication>> GetByStudentIdAsync(int studentId);
        Task<IReadOnlyList<JobApplication>> GetByJobPostingIdAsync(int jobPostingId);
        Task<IReadOnlyList<JobApplication>> GetByStatusAsync(string status);
        Task<JobApplication> GetByStudentAndJobPostingAsync(int studentId, int jobPostingId);
        Task<bool> ExistsForStudentAndJobAsync(int studentId, int jobPostingId);
    }
}