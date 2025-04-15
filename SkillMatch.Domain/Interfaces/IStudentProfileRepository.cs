using SkillMatch.Domain.Entities;

namespace SkillMatch.Domain.Interfaces
{
    public interface IStudentProfileRepository : IRepository<StudentProfile>
    {
        Task<StudentProfile> GetByUserIdAsync(int userId);
        Task<IReadOnlyList<StudentProfile>> GetBySkillAsync(int skillId);
        Task<IReadOnlyList<StudentProfile>> GetByLocationAsync(string location);
        Task<IReadOnlyList<StudentProfile>> GetByAvailabilityAsync(bool isAvailable);
    }
}