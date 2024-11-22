using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Persistence.Contexts;

namespace VacancyManagementApp.Persistence.Repositories
{
    public class VacancyReadRepository : ReadRepository<Vacancy>,
        IVacancyReadRepository
    {
        public VacancyReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
