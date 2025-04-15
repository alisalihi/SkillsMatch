using AutoMapper;
using SkillMatch.Application.DTOs;
using SkillMatch.Application.Interfaces.Services;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;

namespace SkillMatch.Application.Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobPostingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JobPostingDto> CreateJobPostingAsync(CreateJobPostingDto dto)
        {
            var job = _mapper.Map<JobPosting>(dto);
            await _unitOfWork.JobPostings.AddAsync(job);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<JobPostingDto>(job);
        }

        public async Task<JobPostingDto> GetJobPostingByIdAsync(int id)
        {
            var job = await _unitOfWork.JobPostings.GetByIdAsync(id);
            return _mapper.Map<JobPostingDto>(job);
        }

        public async Task<IEnumerable<JobPostingDto>> GetAllJobPostingsAsync()
        {
            var jobs = await _unitOfWork.JobPostings.GetAllAsync();
            return _mapper.Map<IEnumerable<JobPostingDto>>(jobs);
        }

        public async Task<JobPostingDto> UpdateJobPostingAsync(int id, UpdateJobPostingDto dto)
        {
            var job = await _unitOfWork.JobPostings.GetByIdAsync(id);
            if (job == null) throw new Exception("Job posting not found");

            _mapper.Map(dto, job);
            await _unitOfWork.JobPostings.UpdateAsync(job);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<JobPostingDto>(job);
        }

        public async Task<bool> DeleteJobPostingAsync(int id)
        {
            var job = await _unitOfWork.JobPostings.GetByIdAsync(id);
            if (job == null) return false;

            await _unitOfWork.JobPostings.DeleteAsync(job);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<JobPostingDto>> GetJobPostingsByEmployerIdAsync(int employerId)
        {
            var jobs = await _unitOfWork.JobPostings.GetJobPostingsByEmployerIdAsync(employerId);
            return _mapper.Map<IEnumerable<JobPostingDto>>(jobs);
        }
    }
}
