using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Persistence.Contexts;

namespace VacancyManagementApp.Persistence.Repositories
{
    public class AnswerReadRepository : ReadRepository<Answer>, IAnswerReadRepository
    {
        public AnswerReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
