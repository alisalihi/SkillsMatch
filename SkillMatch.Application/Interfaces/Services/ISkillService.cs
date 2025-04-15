using SkillMatch.Application.DTOs;

namespace SkillMatch.Application.Interfaces.Services
{
    public interface ISkillService
    {
        Task<SkillDto> AddSkillAsync(CreateSkillDto dto);
        Task<IEnumerable<SkillDto>> GetAllSkillsAsync();
        Task<SkillDto> UpdateSkillAsync(int id, UpdateSkillDto dto);
        Task<bool> DeleteSkillAsync(int id);
    }
}