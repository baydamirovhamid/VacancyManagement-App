namespace VacancyManagementApp.Application.DTOs.Question
{
    public class AnswerDto
    {
        public string AnswerText { get; set; }
        public Guid QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
