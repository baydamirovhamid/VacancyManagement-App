namespace VacancyManagementApp.Application.DTOs.Question
{
    public class QuestionDto
    {
        public string Description { get; set; }
        public Guid VacancyId { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
