using SkillMatch.Application.DTOs;

namespace SkillMatch.Application.Interfaces.Services
{
    public interface IJobApplicationService
    {
        Task<JobApplicationDto> ApplyForJobAsync(CreateJobApplicationDto dto);
        Task<IEnumerable<JobApplicationDto>> GetApplicationsByJobIdAsync(int jobId);
        Task<IEnumerable<JobApplicationDto>> GetApplicationsByStudentIdAsync(int studentId);
        Task<JobApplicationDto> UpdateApplicationStatusAsync(int id, UpdateJobApplicationDto dto);
        Task<bool> DeleteApplicationAsync(int id);
    }
}