using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.DTOs.Answer
{
    public class GetAllAnswerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
