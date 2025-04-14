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

        Task<int> CompleteAsync();
    }
}
