using SkillMatch.Application.DTOs;

namespace SkillMatch.Application.Interfaces.Services
{
    public interface IStudentProfileService
    {
        Task<StudentProfileDto> CreateStudentProfileAsync(CreateStudentProfileDto dto);
        Task<StudentProfileDto> GetStudentProfileByIdAsync(int id);
        Task<StudentProfileDto> UpdateStudentProfileAsync(int id, UpdateStudentProfileDto dto);
        Task<bool> DeleteStudentProfileAsync(int id);
    }
}
