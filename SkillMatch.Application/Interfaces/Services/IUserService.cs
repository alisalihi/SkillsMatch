using SkillMatch.Application.DTOs;

namespace SkillMatch.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthResponseDto> AuthenticateAsync(AuthRequestDto request);
        Task<UserDto> RegisterUserAsync(CreateUserDto userDto);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<IEnumerable<UserDto>> GetUsersByTypeAsync(string userType);
        Task<UserDto> UpdateUserAsync(int id, UpdateUserDto userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}