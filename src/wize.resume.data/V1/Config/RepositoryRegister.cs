using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using wize.resume.data.V1.Interfaces;
using wize.resume.data.V1.Repositories;

namespace wize.resume.data.V1.Config
{
    public static class RepositoryRegister
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAwardRepository, AwardRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IExperienceItemRepository, ExperienceItemRepository>();
            services.AddScoped<IExperienceTagRepository, ExperienceTagRepository>();
            services.AddScoped<IExpertiseRepository, ExpertiseRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IResumeRepository, ResumeRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IVolunteerRepository, VolunteerRepository>();

            return services;
        }
    }
}
