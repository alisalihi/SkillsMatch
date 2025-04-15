using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillMatch.Domain.Interfaces;
using SkillMatch.Infrastructure.Data;
using SkillMatch.Infrastructure.Identity;
using SkillMatch.Infrastructure.Repositories;

namespace SkillMatch.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Register repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStudentProfileRepository, StudentProfileRepository>();
            services.AddScoped<IEmployerProfileRepository, EmployerProfileRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IJobPostingRepository, JobPostingRepository>();
            services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register auth services
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}