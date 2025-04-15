using SkillMatch.Domain.Interfaces;
using SkillMatch.Infrastructure.Data;
using SkillMatch.Infrastructure.Repositories;

namespace SkillMatch.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IUserRepository Users { get; }
        public IStudentProfileRepository StudentProfiles { get; }
        public IEmployerProfileRepository EmployerProfiles { get; }
        public ISkillRepository Skills { get; }
        public IJobPostingRepository JobPostings { get; }
        public IJobApplicationRepository JobApplications { get; }
        public INotificationRepository Notifications { get; }

        public UnitOfWork(ApplicationDbContext dbContext,
            IUserRepository userRepository,
            IStudentProfileRepository studentProfileRepository,
            IEmployerProfileRepository employerProfileRepository,
            ISkillRepository skillRepository,
            IJobPostingRepository jobPostingRepository,
            IJobApplicationRepository jobApplicationRepository,
            INotificationRepository notificationRepository)
        {
            _dbContext = dbContext;
            Users = userRepository;
            StudentProfiles = studentProfileRepository;
            EmployerProfiles = employerProfileRepository;
            Skills = skillRepository;
            JobPostings = jobPostingRepository;
            JobApplications = jobApplicationRepository;
            Notifications = notificationRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}