using SkillMatch.Application.DTOs;

namespace SkillMatch.Application.Interfaces.Services
{
    public interface IEmployerProfileService
    {
        Task<EmployerProfileDto> CreateEmployerProfileAsync(CreateEmployerProfileDto dto);
        Task<EmployerProfileDto> GetEmployerProfileByIdAsync(int id);
        Task<EmployerProfileDto> UpdateEmployerProfileAsync(int id, UpdateEmployerProfileDto dto);
        Task<bool> DeleteEmployerProfileAsync(int id);
    }
}