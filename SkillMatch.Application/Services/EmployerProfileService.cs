using AutoMapper;
using SkillMatch.Application.DTOs;
using SkillMatch.Application.Interfaces.Services;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;

namespace SkillMatch.Application.Services
{
    public class EmployerProfileService : IEmployerProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployerProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmployerProfileDto> CreateEmployerProfileAsync(CreateEmployerProfileDto dto)
        {
            var profile = _mapper.Map<EmployerProfile>(dto);
            await _unitOfWork.EmployerProfiles.AddAsync(profile);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<EmployerProfileDto>(profile);
        }

        public async Task<EmployerProfileDto> GetEmployerProfileByIdAsync(int id)
        {
            var profile = await _unitOfWork.EmployerProfiles.GetByIdAsync(id);
            return _mapper.Map<EmployerProfileDto>(profile);
        }

        public async Task<EmployerProfileDto> UpdateEmployerProfileAsync(int id, UpdateEmployerProfileDto dto)
        {
            var profile = await _unitOfWork.EmployerProfiles.GetByIdAsync(id);
            if (profile == null) throw new Exception("Employer profile not found");

            _mapper.Map(dto, profile);
            await _unitOfWork.EmployerProfiles.UpdateAsync(profile);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<EmployerProfileDto>(profile);
        }

        public async Task<bool> DeleteEmployerProfileAsync(int id)
        {
            var profile = await _unitOfWork.EmployerProfiles.GetByIdAsync(id);
            if (profile == null) return false;

            await _unitOfWork.EmployerProfiles.DeleteAsync(profile);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
