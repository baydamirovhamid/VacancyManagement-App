using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.Answer;
using VacancyManagementApp.Application.DTOs.ApplicationForm;

namespace VacancyManagementApp.Application.Features.Queries.GetAllAnswer
{
    public class GetAllAnswerQueryResponse
    {
        public List<GetAllAnswerDto> GetAllAnswer { get; set; }

    }
}
