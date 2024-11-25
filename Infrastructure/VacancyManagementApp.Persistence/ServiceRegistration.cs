using Microsoft.Extensions.DependencyInjection;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Persistence.Contexts;
using VacancyManagementApp.Persistence.Services;
using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using VacancyManagementApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using VacancyManagementApp.Application.Abstractions.Services.Authentications;


namespace VacancyManagementApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));


            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IQuestionWriteRepository, QuestionWriteRepository>();

            services.AddScoped<IAnswerReadRepository, AnswerReadRepository>();
            services.AddScoped<IAnswerWriteRepository, AnswerWriteRepository>();

            services.AddScoped<IQuestionReadRepository, QuestionReadRepository>();
            services.AddScoped<IQuestionWriteRepository, QuestionWriteRepository>();

            services.AddScoped<IVacancyWriteRepository, VacancyWriteRepository>();
            services.AddScoped<IVacancyReadRepository, VacancyReadRepository>();

            services.AddScoped<IFileUploadWriteRepository, FileUploadWriteRepository>();
            services.AddScoped<IFileUploadReadRepository, FileUploadReadRepository>();

            services.AddScoped<IApplicationFormReadRepository, ApplicationFormReadRepository>();
            services.AddScoped<IApplicationFormWriteRepository, ApplicationFormWriteRepository>();

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IApplicationFormService, ApplicationFormService>();
            services.AddScoped<IResultService, ResultService>();

            services.AddScoped<IQuestionService, QuestionService>();





        }
    }
}
