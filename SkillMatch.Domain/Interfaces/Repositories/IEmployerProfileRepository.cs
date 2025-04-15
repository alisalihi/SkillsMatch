using SkillMatch.Domain.Entities;

namespace SkillMatch.Domain.Interfaces
{
    public interface IEmployerProfileRepository : IRepository<EmployerProfile>
    {
        Task<EmployerProfile> GetByUserIdAsync(int userId);
        Task<IReadOnlyList<EmployerProfile>> GetByCompanyNameAsync(string companyName);
        Task<IReadOnlyList<EmployerProfile>> GetByIndustryAsync(string industry);
        Task<IReadOnlyList<EmployerProfile>> GetByLocationAsync(string location);
    }
}