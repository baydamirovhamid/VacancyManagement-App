using VacancyManagementApp.Domain.Entities.Identity;

namespace VacancyManagementApp.Application.DTOs.Result
{
    public class GetAllResultDto
    {
        public Guid Id { get; set; }
        public int TrueQuestionCount { get; set; }
        public int FalseAnswerCount { get; set; }
        public int Point { get; set; }
        public Domain.Entities.Vacancy Vacancy { get; set; }
        public Guid VacancyId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
