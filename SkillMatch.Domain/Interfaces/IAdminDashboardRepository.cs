using System;
using System.Threading.Tasks;

namespace SkillMatch.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IStudentProfileRepository StudentProfiles { get; }
        IEmployerProfileRepository EmployerProfiles { get; }
        ISkillRepository Skills { get; }
        IJobPostingRepository JobPostings { get; }
        IJobApplicationRepository JobApplications { get; }
        INotificationRepository Notifications { get; }
        IJobSkillRepository JobSkills { get; }
        IStudentSkillRepository StudentSkills { get; }
        IAdminDashboardRepository AdminDashboard { get; }

        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}