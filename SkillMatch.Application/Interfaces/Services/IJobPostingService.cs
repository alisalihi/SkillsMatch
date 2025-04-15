using SkillMatch.Application.DTOs;

namespace SkillMatch.Application.Interfaces.Services
{
    public interface IJobPostingService
    {
        Task<JobPostingDto> CreateJobPostingAsync(CreateJobPostingDto dto);
        Task<JobPostingDto> GetJobPostingByIdAsync(int id);
        Task<IEnumerable<JobPostingDto>> GetAllJobPostingsAsync();
        Task<JobPostingDto> UpdateJobPostingAsync(int id, UpdateJobPostingDto dto);
        Task<bool> DeleteJobPostingAsync(int id);
        Task<IEnumerable<JobPostingDto>> GetJobPostingsByEmployerIdAsync(int employerId);
    }
}
