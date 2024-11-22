using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Persistence.Contexts;

namespace VacancyManagementApp.Persistence.Repositories
{
    public class QuestionWriteRepository : WriteRepository<Question>, IQuestionWriteRepository
    {
        public QuestionWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
