using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Commands.Question.Remove
{
    public class RemoveQuestionCommandRequest : IRequest<RemoveQuestionCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
