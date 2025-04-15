using AutoMapper;
using SkillMatch.Application.DTOs;
using SkillMatch.Domain.Entities;

namespace SkillMatch.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // StudentProfile mappings
            CreateMap<StudentProfile, StudentProfileDto>()
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills));
            CreateMap<CreateStudentProfileDto, StudentProfile>();
            CreateMap<UpdateStudentProfileDto, StudentProfile>();

            // EmployerProfile mappings
            CreateMap<EmployerProfile, EmployerProfileDto>();
            CreateMap<CreateEmployerProfileDto, EmployerProfile>();
            CreateMap<UpdateEmployerProfileDto, EmployerProfile>();

            // Skill mappings
            CreateMap<Skill, SkillDto>();
            CreateMap<CreateSkillDto, Skill>();

            // StudentSkill mappings
            CreateMap<StudentSkill, StudentSkillDto>()
                .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.Skill.Name))
                .ForMember(dest => dest.SkillCategory, opt => opt.MapFrom(src => src.Skill.Category));
            CreateMap<CreateStudentSkillDto, StudentSkill>();

            // JobPosting mappings
            CreateMap<JobPosting, JobPostingDto>()
                .ForMember(dest => dest.RequiredSkills, opt => opt.MapFrom(src => src.RequiredSkills))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.EmployerProfile.CompanyName));
            CreateMap<CreateJobPostingDto, JobPosting>();
            CreateMap<UpdateJobPostingDto, JobPosting>();

            // JobSkill mappings
            CreateMap<JobSkill, JobSkillDto>()
                .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.Skill.Name))
                .ForMember(dest => dest.SkillCategory, opt => opt.MapFrom(src => src.Skill.Category));
            CreateMap<CreateJobSkillDto, JobSkill>();

            // JobApplication mappings
            CreateMap<JobApplication, JobApplicationDto>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src =>
                    src.StudentProfile.User.FirstName + " " + src.StudentProfile.User.LastName))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobPosting.Title));
            CreateMap<CreateJobApplicationDto, JobApplication>();
            CreateMap<UpdateJobApplicationDto, JobApplication>();

            // Notification mappings
            CreateMap<Notification, NotificationDto>();
            CreateMap<CreateNotificationDto, Notification>();
        }
    }
}