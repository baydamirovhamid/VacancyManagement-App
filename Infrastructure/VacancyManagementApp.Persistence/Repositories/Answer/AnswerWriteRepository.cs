using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Persistence.Contexts;

namespace VacancyManagementApp.Persistence.Repositories
{
    public class AnswerWriteRepository : WriteRepository<Answer>, IAnswerWriteRepository
    {
        public AnswerWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
