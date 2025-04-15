using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;
using SkillMatch.Application.Services;

namespace SkillMatch.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentProfileService, StudentProfileService>();
            services.AddScoped<IEmployerProfileService, EmployerProfileService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IJobPostingService, JobPostingService>();
            services.AddScoped<IJobApplicationService, JobApplicationService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IMatchingService, MatchingService>();

            return services;
        }
    }
}