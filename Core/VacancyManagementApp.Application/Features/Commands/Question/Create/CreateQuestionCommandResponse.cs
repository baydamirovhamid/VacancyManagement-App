using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.Question;

namespace VacancyManagementApp.Application.Features.Commands.Question.Create
{
    public class CreateQuestionCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
