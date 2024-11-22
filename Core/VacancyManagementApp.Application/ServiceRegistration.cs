using Microsoft.Extensions.DependencyInjection;
using MediatR;
using VacancyManagementApp.Application.Extensions;

namespace VacancyManagementApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration).Assembly);

            collection.AddAutoMapper(typeof(MappingEntity).Assembly);

        }
    }
}
