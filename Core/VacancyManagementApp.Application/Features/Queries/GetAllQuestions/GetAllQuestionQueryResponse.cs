using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.Question;

namespace VacancyManagementApp.Application.Features.Queries.GetAllQuestions
{
    public class GetAllQuestionQueryResponse
    {
        public List<GetAllQuestionDto> GetAllQuestionDtos { get; set; } = new();
    }
}
