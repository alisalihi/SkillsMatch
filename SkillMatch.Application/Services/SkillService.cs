using AutoMapper;
using SkillMatch.Application.DTOs;
using SkillMatch.Application.Interfaces.Services;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;

namespace SkillMatch.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SkillDto> AddSkillAsync(CreateSkillDto dto)
        {
            var skill = _mapper.Map<Skill>(dto);
            await _unitOfWork.Skills.AddAsync(skill);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<SkillDto>(skill);
        }

        public async Task<IEnumerable<SkillDto>> GetAllSkillsAsync()
        {
            var skills = await _unitOfWork.Skills.GetAllAsync();
            return _mapper.Map<IEnumerable<SkillDto>>(skills);
        }

        public async Task<SkillDto> UpdateSkillAsync(int id, UpdateSkillDto dto)
        {
            var skill = await _unitOfWork.Skills.GetByIdAsync(id);
            if (skill == null) throw new Exception("Skill not found");

            _mapper.Map(dto, skill);
            await _unitOfWork.Skills.UpdateAsync(skill);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<SkillDto>(skill);
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            var skill = await _unitOfWork.Skills.GetByIdAsync(id);
            if (skill == null) return false;

            await _unitOfWork.Skills.DeleteAsync(skill);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
