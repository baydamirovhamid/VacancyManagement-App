using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Persistence.Contexts;

namespace VacancyManagementApp.Persistence.Repositories
{
    public class VacancyWriteRepository : WriteRepository<Vacancy>,
          IVacancyWriteRepository
    {
        public VacancyWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
