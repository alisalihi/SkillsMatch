using AutoMapper;
using SkillMatch.Application.DTOs;
using SkillMatch.Application.Interfaces.Services;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;

namespace SkillMatch.Application.Services
{
    public class StudentProfileService : IStudentProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StudentProfileDto> CreateStudentProfileAsync(CreateStudentProfileDto dto)
        {
            var profile = _mapper.Map<StudentProfile>(dto);
            await _unitOfWork.StudentProfiles.AddAsync(profile);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<StudentProfileDto>(profile);
        }

        public async Task<StudentProfileDto> GetStudentProfileByIdAsync(int id)
        {
            var profile = await _unitOfWork.StudentProfiles.GetByIdAsync(id);
            return _mapper.Map<StudentProfileDto>(profile);
        }

        public async Task<StudentProfileDto> UpdateStudentProfileAsync(int id, UpdateStudentProfileDto dto)
        {
            var profile = await _unitOfWork.StudentProfiles.GetByIdAsync(id);
            if (profile == null) throw new Exception("Profile not found");

            _mapper.Map(dto, profile);
            await _unitOfWork.StudentProfiles.UpdateAsync(profile);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<StudentProfileDto>(profile);
        }

        public async Task<bool> DeleteStudentProfileAsync(int id)
        {
            var profile = await _unitOfWork.StudentProfiles.GetByIdAsync(id);
            if (profile == null) return false;

            await _unitOfWork.StudentProfiles.DeleteAsync(profile);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
