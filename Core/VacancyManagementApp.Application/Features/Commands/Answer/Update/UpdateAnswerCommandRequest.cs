using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Commands.Answer.Update
{
    public class UpdateAnswerCommandRequest : IRequest<UpdateAnswerCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid QuestionId { get; set; }
    }
}
