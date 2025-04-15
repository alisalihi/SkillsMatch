using AutoMapper;
using SkillMatch.Application.DTOs;
using SkillMatch.Application.Interfaces.Services;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;
using SkillMatch.Infrastructure.Identity;

namespace SkillMatch.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<AuthResponseDto> AuthenticateAsync(AuthRequestDto request)
        {
            var (success, token) = await _authService.AuthenticateAsync(request.Email, request.Password);
            if (!success) return null;
            var user = await _unitOfWork.Users.GetUserByEmailAsync(request.Email);
            return new AuthResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = token,
                UserType = user.UserType
            };
        }

        public async Task<UserDto> RegisterUserAsync(CreateUserDto userDto)
        {
            var existingUser = await _unitOfWork.Users.GetUserByEmailAsync(userDto.Email);
            if (existingUser != null) throw new Exception("Email is already in use");
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _unitOfWork.Users.GetUserByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByTypeAsync(string userType)
        {
            var users = await _unitOfWork.Users.GetUsersByTypeAsync(userType);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) throw new Exception("User not found");
            _mapper.Map(userDto, user);
            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return false;
            await _unitOfWork.Users.DeleteAsync(user);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}