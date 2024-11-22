using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Commands.Answer.Create
{
    public class CreateAnswerCommandRequest:IRequest<CreateAnswerCommandResponse>
    {
        public string Name { get; set; }
        public Guid QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
