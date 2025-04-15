using AutoMapper;
using SkillMatch.Application.DTOs;
using SkillMatch.Application.Interfaces.Services;
using SkillMatch.Domain.Entities;
using SkillMatch.Domain.Interfaces;

namespace SkillMatch.Application.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JobApplicationDto> ApplyForJobAsync(CreateJobApplicationDto dto)
        {
            var application = _mapper.Map<JobApplication>(dto);
            await _unitOfWork.JobApplications.AddAsync(application);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<JobApplicationDto>(application);
        }

        public async Task<IEnumerable<JobApplicationDto>> GetApplicationsByJobIdAsync(int jobId)
        {
            var applications = await _unitOfWork.JobApplications.GetByJobIdAsync(jobId);
            return _mapper.Map<IEnumerable<JobApplicationDto>>(applications);
        }

        public async Task<IEnumerable<JobApplicationDto>> GetApplicationsByStudentIdAsync(int studentId)
        {
            var applications = await _unitOfWork.JobApplications.GetByStudentIdAsync(studentId);
            return _mapper.Map<IEnumerable<JobApplicationDto>>(applications);
        }

        public async Task<JobApplicationDto> UpdateApplicationStatusAsync(int id, UpdateJobApplicationDto dto)
        {
            var application = await _unitOfWork.JobApplications.GetByIdAsync(id);
            if (application == null) throw new Exception("Application not found");

            _mapper.Map(dto, application);
            await _unitOfWork.JobApplications.UpdateAsync(application);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<JobApplicationDto>(application);
        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
            var application = await _unitOfWork.JobApplications.GetByIdAsync(id);
            if (application == null) return false;

            await _unitOfWork.JobApplications.DeleteAsync(application);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
