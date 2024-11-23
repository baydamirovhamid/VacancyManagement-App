using Microsoft.Extensions.DependencyInjection;
using MediatR;
using VacancyManagementApp.Application.Extensions;
using FluentValidation;
using VacancyManagementApp.Application.Validators;

namespace VacancyManagementApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration).Assembly);
            collection.AddValidatorsFromAssemblyContaining<CreateFormValidator>();
            collection.AddAutoMapper(typeof(MappingEntity).Assembly);

        }
    }
}
