using VacancyManagementApp.Domain.Entities.Common;

namespace VacancyManagementApp.Domain.Entities
{
    public class Question:BaseEntity
    {
        public string Description { get; set; }
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
