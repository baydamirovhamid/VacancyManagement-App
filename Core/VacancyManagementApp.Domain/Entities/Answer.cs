using VacancyManagementApp.Domain.Entities.Common;

namespace VacancyManagementApp.Domain.Entities
{
    public class Answer: BaseEntity
    {
        public string Name { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public bool IsCorrect { get; set; }
    }
}
